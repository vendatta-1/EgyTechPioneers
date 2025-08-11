using System.ComponentModel.DataAnnotations;

namespace Dtos.Security;

public class ConfirmEmailDto
{
    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Token { get; set; } = null!;
}