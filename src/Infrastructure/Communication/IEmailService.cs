using Common.Results;

namespace Infrastructure.Communication;

public interface IEmailService
{
    Task<Result> SendAsync(string toEmail, string subject, string body, CancellationToken cancellationToken = default);
    
    Task<Result> SendEmailConfirmationAsync(string toEmail, string confirmationLink, CancellationToken cancellationToken = default);
    
    Task<Result> SendPasswordResetAsync(string toEmail, string resetLink, CancellationToken cancellationToken = default);
    
    Task<Result> SendTwoFactorCodeAsync(string toEmail, string code, CancellationToken cancellationToken = default);

    Task<Result> SendWelcomeEmailAsync(string toEmail, CancellationToken cancellationToken = default);
}