using System.ComponentModel.DataAnnotations;

namespace Dtos.Security;

public class ForgotPasswordDto
{
    [Required, EmailAddress]
    public string Email { get; set; } = null!;
}