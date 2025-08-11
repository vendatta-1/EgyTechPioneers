namespace Infrastructure.Settings;

public class TwilioSettings
{
    public string AccountSid { get; set; } = null!;
    public string AuthToken { get; set; } = null!;
    public string FromPhoneNumber { get; set; } = null!;
}