 
using Infrastructure.Communication;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Logic.Services.Communication;

public class TwilioService : ITwilioService
{
    private readonly TwilioSettings _twilioSettings;

    public TwilioService(IOptions<TwilioSettings> twilioOptions)
    {
        _twilioSettings = twilioOptions.Value;
    }

    public async Task<bool> SendSmsAsync(string toPhoneNumber, string message, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(_twilioSettings.AccountSid) || string.IsNullOrEmpty(_twilioSettings.AuthToken) || string.IsNullOrEmpty(_twilioSettings.FromPhoneNumber))
        {
            // Handle configuration error
            return false;
        }

        TwilioClient.Init(_twilioSettings.AccountSid, _twilioSettings.AuthToken);

        try
        {
            await MessageResource.CreateAsync(
                to: new PhoneNumber(toPhoneNumber),
                from: new PhoneNumber(_twilioSettings.FromPhoneNumber),
                body: message
            );
            return true;
        }
        catch (Exception)
        {
            // Log the exception
            return false;
        }
    }
}