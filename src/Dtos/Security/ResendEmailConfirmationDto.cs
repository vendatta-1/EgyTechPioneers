using System.ComponentModel.DataAnnotations;

namespace Dtos.Security;

public class ResendEmailConfirmationDto
{
    [Required, EmailAddress] public string Email { get; set; } = null!;
}