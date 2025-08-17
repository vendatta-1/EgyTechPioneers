using System.Security.Claims;
using API.Extensions;
using Dtos.Security;
using Logic.Interfaces.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="dto">The registration data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The ID of the newly registered user.</returns>
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IResult> Register([FromBody] RegisterDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.RegisterAsync(dto, cancellationToken);
        return result.Match(
            userId => Results.Created($"/api/account/{userId}", new { UserId = userId }),
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Logs in a user with email and password.
    /// </summary>
    /// <param name="dto">The login credentials.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Authentication tokens.</returns>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IResult> Login([FromBody] LoginDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.LoginAsync(dto, cancellationToken);
        return result.Match(
            Results.Ok,
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Refreshes an access token using a valid refresh token.
    /// </summary>
    /// <param name="dto">The refresh token.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>New authentication tokens.</returns>
    [HttpPost("refresh-token")]
    [AllowAnonymous]
    public async Task<IResult> RefreshToken([FromBody] RefreshTokenDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.RefreshTokenAsync(dto.RefreshToken, cancellationToken);
        return result.Match(
            Results.Ok,
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Revokes a refresh token, invalidating it.
    /// </summary>
    /// <param name="dto">The refresh token to revoke.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpPost("revoke-token")]
    [Authorize]
    public async Task<IResult> RevokeToken([FromBody] RefreshTokenDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.RevokeTokenAsync(dto.RefreshToken, cancellationToken);
        return result.Match(
            () => Results.NoContent(),
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Initiates a password reset process by sending a reset email.
    /// </summary>
    /// <param name="dto">The user's email address.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpPost("forgot-password")]
    [AllowAnonymous]
    public async Task<IResult> ForgotPassword([FromBody] ForgotPasswordDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.ForgotPasswordAsync(dto, cancellationToken);
        return result.Match(
            () => Results.NoContent(),
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Resets a user's password using a valid reset token.
    /// </summary>
    /// <param name="dto">The password reset data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpPost("reset-password")]
    [AllowAnonymous]
    public async Task<IResult> ResetPassword([FromBody] ResetPasswordDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.ResetPasswordAsync(dto, cancellationToken);
        return result.Match(
            () => Results.NoContent(),
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Changes the password for the currently authenticated user.
    /// </summary>
    /// <param name="dto">The password change data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpPut("change-password")]
    [Authorize]
    public async Task<IResult> ChangePassword([FromBody] ChangePasswordDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.ChangePasswordAsync(dto, User, cancellationToken);
        return result.Match(
            () => Results.NoContent(),
            ApiResults.Problem
        );
    }
    
    /// <summary>
    /// Sends an email confirmation link to a user.
    /// </summary>
    /// <param name="dto">The email to send the confirmation to.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpPost("send-email-confirmation")]
    [AllowAnonymous]
    public async Task<IResult> SendEmailConfirmation([FromBody] ResendEmailConfirmationDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.SendEmailConfirmationAsync(dto.Email, cancellationToken);
        return result.Match(
            () => Results.NoContent(),
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Confirms a user's email address with a valid token.
    /// </summary>
    /// <param name="dto">The email confirmation data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpGet("confirm-email")]
    [AllowAnonymous]
    public async Task<IResult> ConfirmEmail([FromQuery] ConfirmEmailDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.ConfirmEmailAsync(dto, cancellationToken);
        return result.Match(
            () => Results.Ok("Email Confirmed Successfully"),
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Sends a confirmation code to a user's phone number.
    /// </summary>
    /// <param name="dto">The phone number to send the code to.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpPost("send-phone-code")]
    [Authorize]
    public async Task<IResult> SendPhoneConfirmationCode([FromBody] SendPhoneCodeDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.SendPhoneConfirmationCodeAsync(dto.PhoneNumber, cancellationToken);
        return result.Match(
            () => Results.NoContent(),
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Confirms a user's phone number with a valid code.
    /// </summary>
    /// <param name="dto">The phone confirmation data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpPost("confirm-phone")]
    [Authorize]
    public async Task<IResult> ConfirmPhone([FromBody] ConfirmPhoneDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.ConfirmPhoneAsync(dto, cancellationToken);
        return result.Match(
            () => Results.NoContent(),
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Enables two-factor authentication for a user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpPost("enable-2fa/{userId:guid}")]
    [Authorize]
    public async Task<IResult> Enable2FA(Guid userId, CancellationToken cancellationToken)
    {
        var result = await _accountService.Enable2FAAsync(userId, cancellationToken);
        return result.Match(
            () => Results.NoContent(),
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Disables two-factor authentication for a user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpPost("disable-2fa/{userId:guid}")]
    [Authorize]
    public async Task<IResult> Disable2FA(Guid userId, CancellationToken cancellationToken)
    {
        var result = await _accountService.Disable2FAAsync(userId, cancellationToken);
        return result.Match(
            () => Results.NoContent(),
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Verifies a 2FA code to complete the 2FA setup.
    /// </summary>
    /// <param name="dto">The 2FA verification data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpPost("verify-2fa")]
    [Authorize]
    public async Task<IResult> Verify2FACode([FromBody] EnableTwoFactorDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.Verify2FACodeAsync(dto, cancellationToken);
        return result.Match(
            () => Results.NoContent(),
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Deactivates a user's account.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpPut("deactivate/{userId:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IResult> DeactivateAccount(Guid userId, CancellationToken cancellationToken)
    {
        var result = await _accountService.DeactivateAccountAsync(userId, cancellationToken);
        return result.Match(
            Results.NoContent,
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Activates a user's account.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpPut("activate/{userId:guid}")]
    [Authorize(Roles="Admin")]
    public async Task<IResult> ActivateAccount(Guid userId, CancellationToken cancellationToken)
    {
        var result = await _accountService.ActivateAccountAsync(userId, cancellationToken);
        return result.Match(
            () => Results.NoContent(),
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Gets the last login time for a user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The last login time.</returns>
    [HttpGet("last-login-time/{userId:guid}")]
    [Authorize]
    public async Task<IResult> GetLastLoginTime(Guid userId, CancellationToken cancellationToken)
    {
        var result = await _accountService.GetLastLoginTimeAsync(userId, cancellationToken);
        return result.Match(
            Results.Ok,
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Uploads a profile picture for a user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="file">The image file to upload.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpPost("profile-picture/{userId:guid}")]
    [Authorize]
    public async Task<IResult> UploadProfilePicture(Guid userId, [FromForm] ProfilePictureUploadDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.UploadProfilePictureAsync(userId, dto.File, cancellationToken);
        return result.Match(
            () => Results.NoContent(),
            ApiResults.Problem
        );
    }
    
    /// <summary>
    /// Retrieves a user's profile picture.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The profile picture file stream.</returns>
    [HttpGet("profile-picture/{userId:guid}")]
    [AllowAnonymous]
    public async Task<IResult> GetProfilePicture(Guid userId, CancellationToken cancellationToken)
    {
        var result = await _accountService.GetProfilePictureAsync(userId, cancellationToken);
        return result.Match(
            data => data.File != null ? Results.File(data.File, data.ContentType, result.Value.FileName) : Results.NotFound(),
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Logs in or registers a user via an external provider (e.g., Google, GitHub).
    /// </summary>
    /// <param name="dto">The external login data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Authentication tokens.</returns>
    [HttpPost("external-login")]
    [AllowAnonymous]
    public async Task<IResult> ExternalLogin([FromBody] ExternalLoginDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.ExternalLoginAsync(dto, cancellationToken);
        return result.Match(
            Results.Ok,
            ApiResults.Problem
        );
    }

    /// <summary>
    /// Links an external account to the current user's account.
    /// </summary>
    /// <param name="userId">The ID of the user to link to.</param>
    /// <param name="dto">The external login data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A success result.</returns>
    [HttpPost("link-external-account/{userId:guid}")]
    [Authorize]
    public async Task<IResult> LinkExternalAccount(Guid userId, [FromBody] ExternalLoginDto dto, CancellationToken cancellationToken)
    {
        var result = await _accountService.LinkExternalAccountAsync(dto, userId, cancellationToken);
        return result.Match(
            () => Results.NoContent(),
            ApiResults.Problem
        );
    }
    [HttpGet("me")]
    [Authorize]  
    public async Task<IResult> GetMe()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null)
            return Results.Unauthorized();

        var result = await _accountService.GetUserAsync(Guid.Parse(userId));
        return result.Match(Results.Ok, ApiResults.Problem);
    }
 
    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Admin,Instructor")]
    public async Task<IResult> GetUserById(Guid id)
    {
        var result = await _accountService.GetUserAsync(id);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

 
  
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IResult> GetAllUsers()
    {
        var result = await _accountService.GetUsersAsync();
        return result.Match(Results.Ok, ApiResults.Problem);
    }
}
