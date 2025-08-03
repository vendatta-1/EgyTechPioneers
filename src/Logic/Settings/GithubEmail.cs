namespace Logic.Settings;

internal class GithubEmail
{
    public string Email { get; set; } = null!;
    public bool Primary { get; set; }
    public bool Verified { get; set; }
    public string? Visibility { get; set; }
}