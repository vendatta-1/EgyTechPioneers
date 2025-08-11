using System.ComponentModel.DataAnnotations;

namespace Dtos.Security;

public class RefreshTokenDto
{
    [Required]
    public string RefreshToken { get; set; } = null!;
}