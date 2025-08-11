namespace Common.Services.Interfaces;


public interface ICurrentUserService
{
    string? UserId { get; }
    string? UserName { get; }
    string? Email { get; }
    string? PhoneNumber { get; }
    string?[] Roles { get; }
    string? IpAddress { get; }

    bool IsAuthenticated { get; }

    /// <summary>Get claim value by type (e.g. "sub", "role", "custom_claim")</summary>
    string? GetClaim(string claimType);

    /// <summary>Get all claims grouped by type</summary>
    IDictionary<string, string[]> GetAllClaims();
}
