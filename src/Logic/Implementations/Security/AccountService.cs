using Common.Results;
using Dtos.Security;
using Entities.Models.Security;
using Infrastructure.Communication;
using Logic.Interfaces.Identity;
using Logic.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Google.Apis.Auth;
using Logic.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Logic.Interfaces.Helpers;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Logic.Services.Identity;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IEmailService _emailService;
    private readonly ITwilioService _twilioService;
    private readonly IFileService _fileService;
    private readonly ILogger<AccountService> _logger;
    private readonly JwtSettings _jwtSettings;
    private readonly IHttpClientFactory _httpClientFactory;

    public AccountService(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IEmailService emailService,
        ITwilioService twilioService,
        IFileService fileService,
        ILogger<AccountService> logger,
        IOptions<JwtSettings> jwtOptions,
        IHttpClientFactory httpClientFactory)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailService = emailService;
        _twilioService = twilioService;
        _fileService = fileService;
        _logger = logger;
        _jwtSettings = jwtOptions.Value;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Result<string>> RegisterAsync(RegisterDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = new AppUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                AcademyDataId = dto.AcademyDataId,
                BranchesDataId = dto.BranchesDataId,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return Result.Failure<string>(Error.Failure("Register.Failed",
                    string.Join(", ", result.Errors.Select(e => e.Description))));

            await _userManager.AddToRoleAsync(user, dto.Role);

            // Send a welcome email. The registration process should not fail if the email service is down.
            var emailResult = await _emailService.SendWelcomeEmailAsync(user.Email!, cancellationToken);
            if (emailResult.IsFailure)
            {
                _logger.LogWarning("Welcome email failed to send for user {UserId}: {ErrorDescription}", user.Id,
                    emailResult.Error.Description);
            }

            return Result.Success(user.Id.ToString());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred during registration for email {Email}.", dto.Email);
            return Result.Failure<string>(Error.Problem("Register.Exception",
                $"An unexpected error occurred during registration: {ex.Message}"));
        }
    }

    public async Task<Result<TokenResultDto>> LoginAsync(LoginDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return Result.Failure<TokenResultDto>(Error.NotFound("User.NotFound",
                    "There is non user with that email"));
            // Always check password to avoid revealing user existence and also ensure lockout
            var passwordCheckResult =
                await _signInManager.CheckPasswordSignInAsync(user, dto.Password, lockoutOnFailure: true);

            if (!passwordCheckResult.Succeeded)
            {
                if (passwordCheckResult.IsLockedOut)
                {
                    return Result<TokenResultDto>.ValidationFailure(Error.Problem("User.LockedOut","User is locked out"));
                }

                if (passwordCheckResult.IsNotAllowed)
                {
                    // If RequireConfirmedEmail is true -> reason is usually unconfirmed email
                    if (_userManager.Options.SignIn.RequireConfirmedEmail && !user.EmailConfirmed)
                    {
                        return Result.Failure<TokenResultDto>(
                            Error.Problem("User.EmailNotConfirmed", "Please confirm your email before logging in"));
                    }

                    return Result.Failure<TokenResultDto>(
                        Error.Problem("User.NotAllowed", "User is not allowed to sign in"));
                }

                if (passwordCheckResult.RequiresTwoFactor)
                {
                    return Result.Failure<TokenResultDto>(Error.Problem("User.RequiresTwoFactor", "Two-factor required"));
                }

                return Result.Failure<TokenResultDto>(Error.Problem("Auth.Failed", "Invalid credentials"));
            }


            user.LastLoginTime = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);


            var token = await GenerateTokenAsync(user); // user! is safe here
            _logger.LogInformation("User logged in successfully: {Email}", dto.Email);

            return Result.Success(token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error during login for email {Email}.", dto.Email);
            return Result.Failure<TokenResultDto>(Error.Problem("Login.Exception", $"Unexpected error: {ex.Message}"));
        }
    }

    public async Task<Result<AppUserDto>> GetUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return Result.Failure<AppUserDto>(Error.NotFound("User.NotFound", "User not found"));
            }

            var dto = user.Adapt<AppUserDto>();

            return Result.Success(dto);
        }
        catch (Exception e)
        {
            return Result.Failure<AppUserDto>(Error.Failure("User.InternalError", e.Message));
        }
    }

    public async Task<Result<IReadOnlyCollection<AppUserDto>>> GetUsersAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            var users = await _userManager.Users.ToListAsync(cancellationToken);
            var dtos = users.Adapt<IReadOnlyCollection<AppUserDto>>();
            return Result.Success(dtos);
        }
        catch (Exception e)
        {
            return Result.Failure<IReadOnlyCollection<AppUserDto>>(Error.Failure("GetUsers.Exception", e.Message));
        }
    }

    private async Task<TokenResultDto> GenerateTokenAsync(AppUser user)
    {
        try
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName)
            };

            authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var refreshToken = GenerateRefreshToken();

            user.RefreshTokens.Add(new RefreshToken
            {
                Token = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                UserId = user.Id
            });

            await _userManager.UpdateAsync(user);

            return new TokenResultDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken,
                ExpiresAt = token.ValidTo
            };
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to generate authentication token.", ex);
        }
    }

    private string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }

    public async Task<Result<TokenResultDto>> RefreshTokenAsync(string refreshToken,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var user = _userManager.Users
                .Include(u => u.RefreshTokens)
                .SingleOrDefault(u => u.RefreshTokens.Any(rt =>
                    rt.Token == refreshToken &&
                    rt.RevokedAt == null &&
                    rt.ExpiresAt > DateTime.UtcNow));
            if (user == null)
                return Result.Failure<TokenResultDto>(Error.NotFound("Token.Invalid",
                    "Invalid or expired refresh token"));

            var token = user.RefreshTokens.First(rt => rt.Token == refreshToken);
            token.RevokedAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            var newToken = await GenerateTokenAsync(user);
            return Result.Success(newToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred during token refresh.");
            return Result.Failure<TokenResultDto>(Error.Problem("RefreshToken.Exception",
                $"An unexpected error occurred during token refresh: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> RevokeTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = _userManager.Users
                .Include(u => u.RefreshTokens)
                .SingleOrDefault(u => u.RefreshTokens.Any(rt =>
                    rt.Token == refreshToken &&
                    rt.RevokedAt == null &&
                    rt.ExpiresAt > DateTime.UtcNow));
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("Token.Invalid", "Invalid or expired refresh token"));

            var token = user.RefreshTokens.First(rt => rt.Token == refreshToken);
            token.RevokedAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred during token revocation.");
            return Result.Failure<bool>(Error.Problem("RevokeToken.Exception",
                $"An unexpected error occurred during token revocation: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> ForgotPasswordAsync(ForgotPasswordDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = $"{UrlsConstants.ResetPasswordUri}?email={user.Email}&token={Uri.EscapeDataString(token)}";

            var emailResult = await _emailService.SendPasswordResetAsync(user.Email!, resetLink, cancellationToken);
            if (emailResult.IsFailure)
            {
                _logger.LogError("Failed to send password reset email to {Email}: {ErrorDescription}", user.Email,
                    emailResult.Error.Description);
                return Result.Failure<bool>(Error.Problem("ForgotPassword.EmailFailed",
                    "Failed to send password reset email."));
            }

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred during password reset request for email {Email}.",
                dto.Email);
            return Result.Failure<bool>(Error.Problem("ForgotPassword.Exception",
                $"An unexpected error occurred during password reset request: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> ResetPasswordAsync(ResetPasswordDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

            var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);
            return result.Succeeded
                ? Result.Success(true)
                : Result.Failure<bool>(Error.Failure("Reset.Failed",
                    string.Join(", ", result.Errors.Select(e => e.Description))));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while resetting password for email {Email}.", dto.Email);
            return Result.Failure<bool>(Error.Problem("ResetPassword.Exception",
                $"An unexpected error occurred while resetting password: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> ChangePasswordAsync(ChangePasswordDto dto, ClaimsPrincipal userPrincipal,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.GetUserAsync(userPrincipal);
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

            var result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);

            return result.Succeeded
                ? Result.Success(true)
                : Result.Failure<bool>(Error.Failure("ChangePassword.Failed",
                    string.Join(", ", result.Errors.Select(e => e.Description))));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while changing password for user {UserId}.",
                userPrincipal?.Identity?.Name);
            return Result.Failure<bool>(Error.Problem("ChangePassword.Exception",
                $"An unexpected error occurred while changing password: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> SendEmailConfirmationAsync(string email,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink =
                $"{UrlsConstants.ConfirmEmailUri}?email={user.Email}&token={Uri.EscapeDataString(token)}";

            var emailResult =
                await _emailService.SendEmailConfirmationAsync(user.Email!, confirmationLink, cancellationToken);
            if (emailResult.IsFailure)
            {
                _logger.LogError("Failed to send email confirmation to {Email}: {ErrorDescription}", user.Email,
                    emailResult.Error.Description);
                return Result.Failure<bool>(Error.Problem("SendEmailConfirmation.EmailFailed",
                    "Failed to send email confirmation."));
            }

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while sending email confirmation to {Email}.", email);
            return Result.Failure<bool>(Error.Problem("SendEmailConfirmation.Exception",
                $"An unexpected error occurred while sending email confirmation: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> ConfirmEmailAsync(ConfirmEmailDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

            var result = await _userManager.ConfirmEmailAsync(user, dto.Token);
            return result.Succeeded
                ? Result.Success(true)
                : Result.Failure<bool>(Error.Failure("EmailConfirm.Failed",
                    string.Join(", ", result.Errors.Select(e => e.Description))));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while confirming email for {Email}.", dto.Email);
            return Result.Failure<bool>(Error.Problem("ConfirmEmail.Exception",
                $"An unexpected error occurred while confirming email: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> SendPhoneConfirmationCodeAsync(string phoneNumber,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber,
                cancellationToken);
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

            var code = GenerateRandomCode(6);
            user.PhoneNumberConfirmationToken = code;
            user.PhoneNumberConfirmationTokenExpiry = DateTime.UtcNow.AddMinutes(5); // 5 minutes expiry

            await _userManager.UpdateAsync(user);

            var result = await _twilioService.SendSmsAsync(phoneNumber, $"Your phone verification code is: {code}",
                cancellationToken);
            if (!result)
                return Result.Failure<bool>(Error.Failure("Sms.Failed", "Failed to send SMS confirmation code."));

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while sending phone confirmation code to {PhoneNumber}.",
                phoneNumber);
            return Result.Failure<bool>(Error.Problem("SendPhoneCode.Exception",
                $"An unexpected error occurred while sending phone code: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> ConfirmPhoneAsync(ConfirmPhoneDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == dto.PhoneNumber,
                cancellationToken);
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

            if (user.PhoneNumberConfirmationToken != dto.Code ||
                user.PhoneNumberConfirmationTokenExpiry <= DateTime.UtcNow)
                return Result.Failure<bool>(Error.Failure("PhoneConfirm.Failed",
                    "Invalid or expired confirmation code."));

            user.PhoneNumberConfirmed = true;
            user.PhoneNumberConfirmationToken = null;
            user.PhoneNumberConfirmationTokenExpiry = null;
            await _userManager.UpdateAsync(user);

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while confirming phone for {PhoneNumber}.",
                dto.PhoneNumber);
            return Result.Failure<bool>(Error.Problem("ConfirmPhone.Exception",
                $"An unexpected error occurred while confirming phone: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> Enable2FAAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

            if (user.PhoneNumber == null || !user.PhoneNumberConfirmed)
                return Result.Failure<bool>(
                    Error.Failure("2FA.Failed", "Phone number must be confirmed to enable 2FA."));

            var code = GenerateRandomCode(6);
            user.TwoFactorAuthenticationToken = code;
            user.TwoFactorAuthenticationTokenExpiry = DateTime.UtcNow.AddMinutes(5);
            await _userManager.UpdateAsync(user);

            var result = await _twilioService.SendSmsAsync(user.PhoneNumber, $"Your 2FA setup code is: {code}",
                cancellationToken);
            if (!result)
                return Result.Failure<bool>(Error.Failure("Sms.Failed", "Failed to send 2FA setup code."));

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while enabling 2FA for user {UserId}.", userId);
            return Result.Failure<bool>(Error.Problem("Enable2FA.Exception",
                $"An unexpected error occurred while enabling 2FA: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> Disable2FAAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

            user.TwoFactorEnabled = false;
            user.TwoFactorAuthenticationToken = null;
            user.TwoFactorAuthenticationTokenExpiry = null;
            await _userManager.UpdateAsync(user);

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while disabling 2FA for user {UserId}.", userId);
            return Result.Failure<bool>(Error.Problem("Disable2FA.Exception",
                $"An unexpected error occurred while disabling 2FA: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> Verify2FACodeAsync(EnableTwoFactorDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

            if (user.TwoFactorAuthenticationToken != dto.Code ||
                user.TwoFactorAuthenticationTokenExpiry <= DateTime.UtcNow)
                return Result.Failure<bool>(Error.Failure("2FA.InvalidCode", "Invalid or expired 2FA code."));

            user.TwoFactorEnabled = true;
            user.TwoFactorAuthenticationToken = null;
            user.TwoFactorAuthenticationTokenExpiry = null;
            await _userManager.UpdateAsync(user);

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while verifying 2FA code for user {UserId}.",
                dto.UserId);
            return Result.Failure<bool>(Error.Problem("Verify2FACode.Exception",
                $"An unexpected error occurred while verifying 2FA code: {ex.Message}"));
        }
    }

    private string GenerateRandomCode(int length)
    {
        const string chars = "0123456789";
        var random = new Random();
        var result = new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        return result;
    }

    public async Task<Result<bool>> DeactivateAccountAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

            user.IsActive = false;
            await _userManager.UpdateAsync(user);

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while deactivating the account for user {UserId}.",
                userId);
            return Result.Failure<bool>(Error.Problem("DeactivateAccount.Exception",
                $"An unexpected error occurred while deactivating the account: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> ActivateAccountAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

            user.IsActive = true;
            await _userManager.UpdateAsync(user);

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while activating the account for user {UserId}.",
                userId);
            return Result.Failure<bool>(Error.Problem("ActivateAccount.Exception",
                $"An unexpected error occurred while activating the account: {ex.Message}"));
        }
    }

    public async Task<Result<DateTime?>> GetLastLoginTimeAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return Result.Failure<DateTime?>(Error.NotFound("User.NotFound", "User not found"));

            return Result.Success(user.LastLoginTime);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while fetching last login time for user {UserId}.",
                userId);
            return Result.Failure<DateTime?>(Error.Problem("GetLastLoginTime.Exception",
                $"An unexpected error occurred while fetching last login time: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> UploadProfilePictureAsync(Guid userId, IFormFile file,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

            user.ProfilePicture = await _fileService.SaveAsync<AppUser>(file);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return Result.Failure<bool>(Error.Problem("User.UpdateFailed",
                    "can not update user-profile image please see logs"));
            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while uploading the profile picture for user {UserId}.",
                userId);
            return Result.Failure<bool>(Error.Problem("FileUpload.Failed",
                $"An unexpected error occurred while uploading the profile picture: {ex.Message}"));
        }
    }

    public async Task<Result<(FileStream? File, string? FileName, string? ContentType)>> GetProfilePictureAsync(
        Guid userId, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return Result.Failure<(FileStream?, string?, string?)>(
                    Error.NotFound("User.NotFound", "User not found"));

            var (fileStream, fileName) = _fileService.Get<AppUser>(user.ProfilePicture);
            if (fileStream == null || fileName == null)
                return Result.Failure<(FileStream?, string?, string?)>(Error.NotFound("File.NotFound",
                    "Profile picture not found."));

            var contentType = _fileService.GetMimeType(Path.GetExtension(fileName));
            return Result.Success((fileStream, fileName, contentType));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while retrieving profile picture for user {UserId}.",
                userId);
            return Result.Failure<(FileStream?, string?, string?)>(Error.Problem("GetProfilePicture.Exception",
                $"An unexpected error occurred while retrieving profile picture: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> LinkExternalAccountAsync(ExternalLoginDto dto, Guid userId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

            var info = new UserLoginInfo(dto.Provider, dto.IdToken, dto.Provider);
            var result = await _userManager.AddLoginAsync(user, info);

            return result.Succeeded
                ? Result.Success(true)
                : Result.Failure<bool>(Error.Failure("External.LinkFailed",
                    string.Join(", ", result.Errors.Select(e => e.Description))));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while linking external account for user {UserId}.",
                userId);
            return Result.Failure<bool>(Error.Problem("LinkExternalAccount.Exception",
                $"An unexpected error occurred while linking external account: {ex.Message}"));
        }
    }

    public async Task<Result<TokenResultDto>> ExternalLoginAsync(ExternalLoginDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            string? email = null;
            string? providerKey = null;

            var provider = dto.Provider.ToLower();

            if (provider == "google")
            {
                var payload = await ValidateGoogleTokenAsync(dto.IdToken);
                if (payload == null || string.IsNullOrEmpty(payload.Email))
                    return Result.Failure<TokenResultDto>(
                        Error.Failure("External.InvalidToken", "Invalid Google token"));

                email = payload.Email;
                providerKey = payload.Subject; // stable unique ID
            }
            else if (provider == "github")
            {
                if (string.IsNullOrEmpty(dto.AccessToken))
                    return Result.Failure<TokenResultDto>(Error.Failure("External.MissingToken",
                        "GitHub access token is required"));

                email = await GetGithubEmailAsync(dto.AccessToken);
                if (string.IsNullOrEmpty(email))
                    return Result.Failure<TokenResultDto>(Error.Failure("External.InvalidToken",
                        "Unable to retrieve email from GitHub"));

                providerKey = await GetGithubUserIdAsync(dto.AccessToken);
                if (string.IsNullOrEmpty(providerKey))
                    return Result.Failure<TokenResultDto>(Error.Failure("External.InvalidToken",
                        "Unable to retrieve GitHub user ID"));
            }
            else
            {
                return Result.Failure<TokenResultDto>(Error.Failure("External.ProviderNotSupported",
                    "Unsupported provider"));
            }

            var user = await _userManager.FindByEmailAsync(email);
            var info = new UserLoginInfo(dto.Provider, providerKey, dto.Provider);

            if (user == null)
            {
                user = new AppUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = email,
                    LastName = dto.Provider,
                    IsActive = true,
                    EmailConfirmed = true
                };

                var createResult = await _userManager.CreateAsync(user);
                if (!createResult.Succeeded)
                    return Result.Failure<TokenResultDto>(Error.Failure("External.RegisterFailed",
                        string.Join(", ", createResult.Errors.Select(e => e.Description))));

                await _userManager.AddLoginAsync(user, info);
                await _userManager.AddToRoleAsync(user, "User");
            }
            else
            {
                var logins = await _userManager.GetLoginsAsync(user);
                if (!logins.Any(l => l.LoginProvider == dto.Provider && l.ProviderKey == providerKey))
                    await _userManager.AddLoginAsync(user, info);
            }

            var token = await GenerateTokenAsync(user);
            return Result.Success(token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred during external login with provider {Provider}.",
                dto.Provider);
            return Result.Failure<TokenResultDto>(Error.Problem("ExternalLogin.Exception",
                $"An unexpected error occurred: {ex.Message}"));
        }
    }

    private async Task<GoogleJsonWebSignature.Payload?> ValidateGoogleTokenAsync(string idToken)
    {
        try
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { _jwtSettings.Issuer }
            };
            return await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to validate Google token.");
            return null;
        }
    }

    private async Task<string?> GetGithubEmailAsync(string accessToken)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("ChatApp", "1.0"));

            var response = await client.GetAsync("https://api.github.com/user/emails");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("GitHub API call failed with status code {StatusCode}.", response.StatusCode);
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var emails = JsonSerializer.Deserialize<List<GithubEmail>>(content);
            return emails?.FirstOrDefault(e => e.Primary && e.Verified)?.Email;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while retrieving GitHub email.");
            return null;
        }
    }

    private async Task<string?> GetGithubUserIdAsync(string accessToken)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("ChatApp", "1.0"));

            var response = await client.GetAsync("https://api.github.com/user");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("GitHub API call failed with status code {StatusCode}.", response.StatusCode);
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<GithubUser>(content);
            return user?.Id.ToString();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while retrieving GitHub user ID.");
            return null;
        }
    }
}