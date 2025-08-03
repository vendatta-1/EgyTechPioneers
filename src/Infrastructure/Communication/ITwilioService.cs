namespace Infrastructure.Communication;

public interface ITwilioService
{
    Task<bool> SendSmsAsync(string toPhoneNumber, string message, CancellationToken cancellationToken = default);
}