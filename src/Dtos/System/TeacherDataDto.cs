using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dtos.System
{
    public class TeacherDataDto
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid AcademyDataId { get; set; }

        [Required]
        public Guid BranchesDataId { get; set; }

        public Guid? CountryCodeId { get; set; }

        public Guid? GovernorateCodeId { get; set; }

        public Guid? CityCodeId { get; set; }

        [Required(ErrorMessage = "Teacher name (L1) is required.")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 70 characters.")]
        public string TeacherNameL1 { get; set; } = null!;

        [StringLength(70, MinimumLength = 3, ErrorMessage = "Name (L2) must be between 3 and 70 characters.")]
        public string? TeacherNameL2 { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Address must be between 3 and 150 characters.")]
        public string TeacherAddress { get; set; } = null!;

        [Required(ErrorMessage = "National ID is required.")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "National ID must be exactly 14 numeric digits.")]
        public string NationalId { get; set; } = null!;

        public DateOnly? DateStart { get; set; }

        [Phone(ErrorMessage = "Invalid mobile number format.")]
        [StringLength(12, MinimumLength = 7, ErrorMessage = "Mobile number must be between 7 and 12 characters.")]
        public string? TeacherMobile { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(12, MinimumLength = 7, ErrorMessage = "Phone number must be between 7 and 12 characters.")]
        public string? TeacherPhone { get; set; }

        [Required(ErrorMessage = "WhatsApp number is required.")]
        [RegularExpression(@"^\d{11,12}$", ErrorMessage = "WhatsApp number must be between 11 and 12 digits.")]
        public string TeacherWhatsapp { get; set; } = null!;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "Email must be between 10 and 80 characters.")]
        public string TeacherEmail { get; set; } = null!;

        public IFormFile? ImageFile { get; set; }

        [StringLength(500, ErrorMessage = "Description can't exceed 500 characters.")]
        public string? Description { get; set; }

        public DateOnly? TeacherCancel { get; set; }
    }
}
