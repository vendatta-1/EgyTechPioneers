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
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Logic.Services.Identity;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IEmailService _emailService;
    private readonly JwtSettings _jwtSettings;
    private readonly IHttpClientFactory _httpClientFactory;

    public AccountService(UserManager<AppUser> userManager, 
        SignInManager<AppUser> signInManager, 
        IEmailService emailService, 
        IOptions<JwtSettings> jwtOptions,
        IHttpClientFactory httpClientFactory)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailService = emailService;
        _jwtSettings = jwtOptions.Value;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Result<string>> RegisterAsync(RegisterDto dto, CancellationToken cancellationToken = default)
    {
        var user = new AppUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            CompanyDataId = dto.CompanyDataId,
            BranchesDataId = dto.BranchesDataId,
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
            return Result.Failure<string>(Error.Failure("Register.Failed", string.Join(", ", result.Errors.Select(e => e.Description))));

        await _userManager.AddToRoleAsync(user, "User");

        return Result.Success(user.Id.ToString());
    }

    public async Task<Result<TokenResultDto>> LoginAsync(LoginDto dto, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null || !user.IsActive)
            return Result.Failure<TokenResultDto>(Error.NotFound("User.NotFound", "Invalid credentials"));

        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
        if (!result.Succeeded)
            return Result.Failure<TokenResultDto>(Error.Failure("Auth.Failed", "Invalid credentials"));

        user.LastLoginTime = DateTime.UtcNow;
        await _userManager.UpdateAsync(user);

        var token = await GenerateTokenAsync(user);
        return Result.Success(token);
    }

    private async Task<TokenResultDto> GenerateTokenAsync(AppUser user)
    {
        var userRoles = await _userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
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

    private string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }

    public async Task<Result<TokenResultDto>> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.RefreshTokens.Any(rt => rt.Token == refreshToken && rt.IsActive));
        if (user == null)
            return Result.Failure<TokenResultDto>(Error.NotFound("Token.Invalid", "Invalid or expired refresh token"));

        var token = user.RefreshTokens.First(rt => rt.Token == refreshToken);
        token.RevokedAt = DateTime.UtcNow;
        await _userManager.UpdateAsync(user);

        var newToken = await GenerateTokenAsync(user);
        return Result.Success(newToken);
    }

    public async Task<Result<bool>> RevokeTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.RefreshTokens.Any(rt => rt.Token == refreshToken && rt.IsActive));
        if (user == null)
            return Result.Failure<bool>(Error.NotFound("Token.Invalid", "Invalid or expired refresh token"));

        var token = user.RefreshTokens.First(rt => rt.Token == refreshToken);
        token.RevokedAt = DateTime.UtcNow;
        await _userManager.UpdateAsync(user);

        return Result.Success(true);
    }

    public async Task<Result<bool>> ForgotPasswordAsync(ForgotPasswordDto dto, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
            return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var resetLink = $"https://your-app/reset-password?email={user.Email}&token={Uri.EscapeDataString(token)}";
        await _emailService.SendPasswordResetAsync(user.Email!, resetLink, cancellationToken);

        return Result.Success(true);
    }

    public async Task<Result<bool>> ResetPasswordAsync(ResetPasswordDto dto, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
            return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

        var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);
        return result.Succeeded ? Result.Success(true) : Result.Failure<bool>(Error.Failure("Reset.Failed", string.Join(", ", result.Errors.Select(e => e.Description))));
    }

    public async Task<Result<bool>> ChangePasswordAsync(ChangePasswordDto dto, ClaimsPrincipal userPrincipal, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.GetUserAsync(userPrincipal);
        if (user == null)
            return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

        var result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
        return result.Succeeded ? Result.Success(true) : Result.Failure<bool>(Error.Failure("ChangePassword.Failed", string.Join(", ", result.Errors.Select(e => e.Description))));
    }

    public async Task<Result<bool>> SendEmailConfirmationAsync(string email, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var confirmationLink = $"https://your-app/confirm-email?email={user.Email}&token={Uri.EscapeDataString(token)}";
        await _emailService.SendEmailConfirmationAsync(user.Email!, confirmationLink, cancellationToken);

        return Result.Success(true);
    }

    public async Task<Result<bool>> ConfirmEmailAsync(ConfirmEmailDto dto, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
            return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

        var result = await _userManager.ConfirmEmailAsync(user, dto.Token);
        return result.Succeeded ? Result.Success(true) : Result.Failure<bool>(Error.Failure("EmailConfirm.Failed", string.Join(", ", result.Errors.Select(e => e.Description))));
    }

    public Task<Result<bool>> SendPhoneConfirmationCodeAsync(string phoneNumber, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Result.Failure<bool>(Error.Failure("NotImplemented", "SMS sending not implemented")));
    }

    public async Task<Result<bool>> ConfirmPhoneAsync(ConfirmPhoneDto dto, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == dto.PhoneNumber, cancellationToken);
        if (user == null)
            return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

        user.PhoneNumberConfirmed = true;
        await _userManager.UpdateAsync(user);

        return Result.Success(true);
    }

    public Task<Result<bool>> Enable2FAAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Result.Failure<bool>(Error.Failure("NotImplemented", "2FA setup not implemented")));
    }

    public Task<Result<bool>> Disable2FAAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Result.Failure<bool>(Error.Failure("NotImplemented", "2FA disable not implemented")));
    }

    public Task<Result<bool>> Verify2FACodeAsync(EnableTwoFactorDto dto, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Result.Failure<bool>(Error.Failure("NotImplemented", "2FA code verification not implemented")));
    }
    
    public async Task<Result<bool>> DeactivateAccountAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
            return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

        user.IsActive = false;
        await _userManager.UpdateAsync(user);

        return Result.Success(true);
    }

    public async Task<Result<bool>> ActivateAccountAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
            return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

        user.IsActive = true;
        await _userManager.UpdateAsync(user);

        return Result.Success(true);
    }

    public async Task<Result<DateTime?>> GetLastLoginTimeAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
            return Result.Failure<DateTime?>(Error.NotFound("User.NotFound", "User not found"));

        return Result.Success(user.LastLoginTime);
    }

    public Task<Result<bool>> UploadProfilePictureAsync(Guid userId, IFormFile file, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Result.Failure<bool>(Error.Failure("NotImplemented", "Upload profile picture not implemented")));
    }

    public Task<Result<(FileStream? File, string? ContentType)>> GetProfilePictureAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Result.Failure<(FileStream?, string?)>(Error.Failure("NotImplemented", "Get profile picture not implemented")));
    }
    public async Task<Result<TokenResultDto>> ExternalLoginAsync(ExternalLoginDto dto, CancellationToken cancellationToken = default)
    {
        string? email = null;

        if (dto.Provider.ToLower() == "google")
        {
            var payload = await ValidateGoogleTokenAsync(dto.IdToken);
            if (payload == null || string.IsNullOrEmpty(payload.Email))
                return Result.Failure<TokenResultDto>(Error.Failure("External.InvalidToken", "Invalid Google token"));
            email = payload.Email;
        }
        else if (dto.Provider.ToLower() == "github")
        {
            email = await GetGithubEmailAsync(dto.AccessToken);
            if (string.IsNullOrEmpty(email))
                return Result.Failure<TokenResultDto>(Error.Failure("External.InvalidToken", "Unable to retrieve email from GitHub"));
        }
        else
        {
            return Result.Failure<TokenResultDto>(Error.Failure("External.ProviderNotSupported", "Unsupported provider"));
        }

        var user = await _userManager.FindByEmailAsync(email);
        var info = new UserLoginInfo(dto.Provider, dto.IdToken, dto.Provider);

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
                return Result.Failure<TokenResultDto>(Error.Failure("External.RegisterFailed", string.Join(", ", createResult.Errors.Select(e => e.Description))));

            await _userManager.AddLoginAsync(user, info);
            await _userManager.AddToRoleAsync(user, "User");
        }
        else
        {
            var logins = await _userManager.GetLoginsAsync(user);
            if (!logins.Any(l => l.LoginProvider == dto.Provider && l.ProviderKey == dto.IdToken))
                await _userManager.AddLoginAsync(user, info);
        }

        var token = await GenerateTokenAsync(user);
        return Result.Success(token);
    }

    public async Task<Result<bool>> LinkExternalAccountAsync(ExternalLoginDto dto, Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
            return Result.Failure<bool>(Error.NotFound("User.NotFound", "User not found"));

        var info = new UserLoginInfo(dto.Provider, dto.IdToken, dto.Provider);
        var result = await _userManager.AddLoginAsync(user, info);

        return result.Succeeded
            ? Result.Success(true)
            : Result.Failure<bool>(Error.Failure("External.LinkFailed", string.Join(", ", result.Errors.Select(e => e.Description))));
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
        catch
        {
            return null;
        }
    }

    private async Task<string?> GetGithubEmailAsync(string accessToken)
    {
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("ChatApp", "1.0"));

        var response = await client.GetAsync("https://api.github.com/user/emails");
        if (!response.IsSuccessStatusCode) return null;

        var content = await response.Content.ReadAsStringAsync();
        var emails = JsonSerializer.Deserialize<List<GithubEmail>>(content);
        return emails?.FirstOrDefault(e => e.Primary && e.Verified)?.Email;
    }

    private class GithubEmail
    {
        public string Email { get; set; } = null!;
        public bool Primary { get; set; }
        public bool Verified { get; set; }
        public string? Visibility { get; set; }
    }

}
