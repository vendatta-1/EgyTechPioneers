namespace Entities.Models.Chat;

public class SupportAgent
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public DateTime? LastActive { get; set; }
    public bool IsOnline { get; set; }
}