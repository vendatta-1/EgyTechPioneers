using System;
using System.ComponentModel.DataAnnotations;

namespace Dtos.Security
{
    public class AppUserDto
    {
        public Guid? Id { get; set; }

        public Guid? AcademyDataId { get; set; }

        public Guid? BranchesDataId { get; set; }

        [Required, MaxLength(60)] public string FirstName { get; set; } = null!;

        [Required, MaxLength(60)] public string LastName { get; set; } = null!;

        [Required, EmailAddress] public string Email { get; set; } = null!;

        [Phone] 
        public string? PhoneNumber { get; set; }

        public string? ProfilePicture { get; set; }
        
        public bool IsActive { get; set; }
        
        public bool EmailConfirmed { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginTime { get; set; }
    }
}