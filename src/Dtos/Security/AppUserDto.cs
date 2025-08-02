using System;
using System.ComponentModel.DataAnnotations;

namespace Dtos.Security
{
    public class AppUserDto
    {
        public Guid? Id { get; set; }  

        public Guid? CompanyDataId { get; set; }
        public Guid? BranchesDataId { get; set; }

        [Required, MaxLength(60)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(60)]
        public string LastName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; }

        public string? ProfilePicture { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginTime { get; set; }
    }
}