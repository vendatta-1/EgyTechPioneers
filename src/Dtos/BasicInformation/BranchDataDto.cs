using System;
using System.ComponentModel.DataAnnotations;

namespace Dtos.BasicInformation
{
    public class BranchDataDto
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid AcademyDataId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string BranchNameL1 { get; set; }

        [StringLength(100)]
        [Required]
        public string BranchNameL2 { get; set; }

        public Guid? CountryCodeId { get; set; }
        public Guid? GovernorateCodeId { get; set; }
        public Guid? CityCodeId { get; set; }

        [Required]
        [StringLength(250)]
        public string BranchAddress { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"^\d+$", ErrorMessage = "Value must contain only digits.")]
        [MaxLength(12)]
        public string BranchMobile { get; set; }

        [Phone]
        [RegularExpression(@"^\d+$", ErrorMessage = "Value must contain only digits.")]
        [MaxLength(12)]
        public string? BranchPhone { get; set; }

        [Phone]
        [RegularExpression(@"^\d+$", ErrorMessage = "Value must contain only digits.")]
        [MaxLength(12)]
        public string? BranchWhatsapp { get; set; }

        [EmailAddress]
        [MaxLength(150)]
        public string BranchEmail { get; set; }

        public Guid? BranchManager { get; set; }
    }
}