using System.ComponentModel.DataAnnotations;

namespace Dtos.Security;

public abstract class SendPhoneCodeDto
{
    [Required]
    public string PhoneNumber { get; set; } = null!;
}