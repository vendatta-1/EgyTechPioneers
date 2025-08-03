namespace Dtos.Security;

public class EnableTwoFactorDto
{
    public Guid UserId { get; set; }
 
    public string Code { get; set; }
}