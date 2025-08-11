using Common.Results;
using Dtos.Security;

 
using Common.Results;
using Dtos.Security;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Logic.Interfaces.Identity;

public interface IAccountService
{
    
    Task<Result<string>> RegisterAsync(RegisterDto dto, CancellationToken cancellationToken = default);
    Task<Result<TokenResultDto>> LoginAsync(LoginDto dto, CancellationToken cancellationToken = default);

    Task<Result<AppUserDto>> GetUserAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<AppUserDto>>> GetUsersAsync(CancellationToken cancellationToken = default);
    Task<Result<TokenResultDto>> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default);
    Task<Result<bool>> RevokeTokenAsync(string refreshToken, CancellationToken cancellationToken = default);

 
    Task<Result<bool>> ForgotPasswordAsync(ForgotPasswordDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> ResetPasswordAsync(ResetPasswordDto dto, CancellationToken cancellationToken = default);

 
    Task<Result<bool>> ChangePasswordAsync(ChangePasswordDto dto, ClaimsPrincipal user, CancellationToken cancellationToken = default);

   
    Task<Result<bool>> SendEmailConfirmationAsync(string email, CancellationToken cancellationToken = default);
    Task<Result<bool>> ConfirmEmailAsync(ConfirmEmailDto dto, CancellationToken cancellationToken = default);

    
    Task<Result<bool>> SendPhoneConfirmationCodeAsync(string phoneNumber, CancellationToken cancellationToken = default);
    Task<Result<bool>> ConfirmPhoneAsync(ConfirmPhoneDto dto, CancellationToken cancellationToken = default);

    
    Task<Result<bool>> Enable2FAAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Result<bool>> Disable2FAAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Result<bool>> Verify2FACodeAsync(EnableTwoFactorDto dto, CancellationToken cancellationToken = default);

   
    Task<Result<TokenResultDto>> ExternalLoginAsync(ExternalLoginDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> LinkExternalAccountAsync(ExternalLoginDto dto, Guid userId, CancellationToken cancellationToken = default);

 
    Task<Result<bool>> DeactivateAccountAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Result<bool>> ActivateAccountAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Result<DateTime?>> GetLastLoginTimeAsync(Guid userId, CancellationToken cancellationToken = default);
 
    Task<Result<bool>> UploadProfilePictureAsync(Guid userId, IFormFile file, CancellationToken cancellationToken = default);
    Task<Result<(FileStream? File, string? ContentType)>> GetProfilePictureAsync(Guid userId, CancellationToken cancellationToken = default);
}
