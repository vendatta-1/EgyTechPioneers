using System.ComponentModel.DataAnnotations;

namespace Dtos.Security;

public class ChangePasswordDto
{
    [Required]
    public string CurrentPassword { get; set; } = null!;

    [Required, MinLength(6)]
    public string NewPassword { get; set; } = null!;
}