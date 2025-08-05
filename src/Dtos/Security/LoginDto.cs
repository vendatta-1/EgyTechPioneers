using System.ComponentModel.DataAnnotations;

namespace Dtos.Security;

public class LoginDto
{
    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
    
   
}