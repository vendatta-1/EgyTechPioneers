using Common.Results;
using Infrastructure.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Infrastructure.Communication;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtp;

    public EmailService(IOptions<SmtpSettings> smtpOptions)
    {
        _smtp = smtpOptions.Value;
    }

    public async Task<Result> SendAsync(string toEmail, string subject, string body, CancellationToken cancellationToken = default)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_smtp.SenderName, _smtp.SenderEmail));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = body };
            message.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(_smtp.Host, _smtp.Port, SecureSocketOptions.StartTls, cancellationToken);
            await client.AuthenticateAsync(_smtp.Username, _smtp.Password, cancellationToken);
            await client.SendAsync(message, cancellationToken);
            await client.DisconnectAsync(true, cancellationToken);

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(Error.Failure("Send.Failed", ex.Message));
        }
    }

    public async Task<Result> SendEmailConfirmationAsync(string toEmail, string confirmationLink, CancellationToken cancellationToken = default)
    {
        var body = EmailTemplates.ConfirmationEmail(confirmationLink);
        return await SendAsync(toEmail, "Confirm Your Email", body, cancellationToken);
    }

    public async Task<Result> SendPasswordResetAsync(string toEmail, string resetLink, CancellationToken cancellationToken = default)
    {
        var body = EmailTemplates.PasswordReset(resetLink);
        return await SendAsync(toEmail, "Reset Your Password", body, cancellationToken);
    }

    public async Task<Result> SendTwoFactorCodeAsync(string toEmail, string code, CancellationToken cancellationToken = default)
    {
        var body = EmailTemplates.TwoFactorCode(code);
        return await SendAsync(toEmail, "Your Two-Factor Code", body, cancellationToken);
    }

    public async Task<Result> SendWelcomeEmailAsync(string toEmail, CancellationToken cancellationToken = default)
    {
        var body = EmailTemplates.WelcomeEmail(toEmail);
        return await SendAsync(toEmail, "Welcome to Our Platform", body, cancellationToken);
    }
}