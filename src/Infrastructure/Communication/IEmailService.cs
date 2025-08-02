namespace Infrastructure.Communication;

public interface IEmailService
{
    Task<bool> SendAsync(string toEmail, string subject, string body, CancellationToken cancellationToken = default);
    
    Task<bool> SendEmailConfirmationAsync(string toEmail, string confirmationLink, CancellationToken cancellationToken = default);
    
    Task<bool> SendPasswordResetAsync(string toEmail, string resetLink, CancellationToken cancellationToken = default);
    
    Task<bool> SendTwoFactorCodeAsync(string toEmail, string code, CancellationToken cancellationToken = default);

    Task<bool> SendWelcomeEmailAsync(string toEmail, CancellationToken cancellationToken = default);
}