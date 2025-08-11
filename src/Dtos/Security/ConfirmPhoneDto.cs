using System.ComponentModel.DataAnnotations;

namespace Dtos.Security;

public class ConfirmPhoneDto
{
    [Required]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public string Code { get; set; } = null!;
}