using System.ComponentModel.DataAnnotations;

namespace Dtos.Security
{
    public class RegisterDto
    {
        [Required, MaxLength(60)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(60)]
        public string LastName { get; set; } = null!;

        [Required]
        // [RegularExpression("(?i)^(User|Student|Instructor|SupportAgent)$", ErrorMessage = "Role must be one of: User, Student, Instructor, SupportAgent.")]
        public string Role { get; set; } = null!;
        public Guid? AcademyDataId { get; set; }
        public Guid? BranchesDataId { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}