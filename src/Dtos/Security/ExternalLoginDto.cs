using System.ComponentModel.DataAnnotations;

namespace Dtos.Security;

public class ExternalLoginDto
{
    [Required]
    public string Provider { get; set; } = null!;  

    [Required]
    public string IdToken { get; set; } = null!;

    public string AccessToken { get; set; } = null!;
}