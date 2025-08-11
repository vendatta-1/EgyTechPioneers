using Common.Services.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Common.Services.Implementations;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public string? UserId => GetClaimValue(ClaimTypes.NameIdentifier);
    public string? UserName => GetClaimValue(ClaimTypes.Name);
    public string? Email => GetClaimValue(ClaimTypes.Email);
    public string? PhoneNumber => GetClaimValue(ClaimTypes.MobilePhone);
    public string? Role => GetClaimValue(ClaimTypes.Role);
    public string?[] Roles => GetClaimValues(ClaimTypes.Role);
    public string? IpAddress => _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
    public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    public IEnumerable<Claim> Claims => _httpContextAccessor.HttpContext?.User?.Claims ?? [];

    public string? GetClaim(string claimType)
        => _httpContextAccessor.HttpContext?.User?.FindFirst(claimType)?.Value;

    public IDictionary<string, string[]> GetAllClaims()
    {
        return Claims
            .GroupBy(c => c.Type)
            .ToDictionary(g => g.Key, g => g.Select(c => c.Value).ToArray());
    }

    private string? GetClaimValue(string type)
        => _httpContextAccessor.HttpContext?.User?.FindFirst(type)?.Value;

    private string?[] GetClaimValues(string type)
        => _httpContextAccessor.HttpContext?.User?.Claims
            .Where(c => c.Type == type)
            .Select(c => c.Value)
            .ToArray();
}