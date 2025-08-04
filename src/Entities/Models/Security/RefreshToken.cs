using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace Entities.Models.Security;

public class RefreshToken : Entity
{
    [Required]
    public string Token { get; set; } = null!;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? RevokedAt { get; set; }

    [Required]
    public DateTime ExpiresAt { get; set; }

    [Required]
    public Guid UserId { get; set; }  

    [ForeignKey(nameof(UserId))]
    public AppUser User { get; set; } = default!;

    [NotMapped]
    public bool IsRevoked => RevokedAt.HasValue;
    [NotMapped]
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
    [NotMapped]
    public bool IsActive => !IsRevoked && !IsExpired;
}