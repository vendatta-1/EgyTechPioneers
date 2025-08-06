using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models.Security;

public class AppUser : IdentityUser<Guid>
{
    public Guid? AcademyDataId { get; set; }
    public Guid? BranchesDataId { get; set; }
    [Required]
    [MaxLength(60)]
    public string FirstName { get; set; } = null!;
    [Required]
    [MaxLength(60)]
    public string LastName { get; set; } = null!;
    [MaxLength(250)]
    public string? ProfilePicture { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginTime { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    public string? PhoneNumberConfirmationToken { get; set; }
    public DateTime? PhoneNumberConfirmationTokenExpiry { get; set; }

    public string? TwoFactorAuthenticationToken { get; set; }
    public DateTime? TwoFactorAuthenticationTokenExpiry { get; set; }
}
