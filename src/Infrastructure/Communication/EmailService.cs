using Infrastructure.Settings;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Razor.Templating.Core;

namespace Infrastructure.Communication;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtp;

    public EmailService(IOptions<SmtpSettings> smtpOptions)
    {
        _smtp = smtpOptions.Value;
    }

    public async Task<bool> SendAsync(string toEmail, string subject, string body, CancellationToken cancellationToken = default)
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
            await client.ConnectAsync(_smtp.Host, _smtp.Port, _smtp.UseSsl, cancellationToken);
            await client.AuthenticateAsync(_smtp.Username, _smtp.Password, cancellationToken);
            await client.SendAsync(message, cancellationToken);
            await client.DisconnectAsync(true, cancellationToken);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> SendEmailConfirmationAsync(string toEmail, string confirmationLink, CancellationToken cancellationToken = default)
    {
        var body = await RazorTemplateEngine.RenderAsync("EmailTemplates/ConfirmEmail.cshtml", new { ConfirmationLink = confirmationLink });
        return await SendAsync(toEmail, "Confirm Your Email", body, cancellationToken);
    }

    public async Task<bool> SendPasswordResetAsync(string toEmail, string resetLink, CancellationToken cancellationToken = default)
    {
        var body = await RazorTemplateEngine.RenderAsync("EmailTemplates/ResetPassword.cshtml", new { ResetLink = resetLink });
        return await SendAsync(toEmail, "Reset Your Password", body, cancellationToken);
    }

    public async Task<bool> SendTwoFactorCodeAsync(string toEmail, string code, CancellationToken cancellationToken = default)
    {
        var body = await RazorTemplateEngine.RenderAsync("EmailTemplates/TwoFactorCode.cshtml", new { Code = code });
        return await SendAsync(toEmail, "Your Two-Factor Code", body, cancellationToken);
    }

    public async Task<bool> SendWelcomeEmailAsync(string toEmail, CancellationToken cancellationToken = default)
    {
        var body = await RazorTemplateEngine.RenderAsync("EmailTemplates/Welcome.cshtml", new { Email = toEmail });
        return await SendAsync(toEmail, "Welcome to Our Platform", body, cancellationToken);
    }
}
