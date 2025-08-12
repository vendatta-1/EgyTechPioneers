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
        public string? BranchNameL2 { get; set; }

        public Guid? CountryCodeId { get; set; }
        public Guid? GovernorateCodeId { get; set; }
        public Guid? CityCodeId { get; set; }

        [Required]
        [StringLength(250)]
        public string BranchAddress { get; set; }

        [Required]
        [Phone]
        public string BranchMobile { get; set; }

        [Phone]
        public string BranchPhone { get; set; }

        [Phone]
        public string BranchWhatsapp { get; set; }

        [EmailAddress]
        public string BranchEmail { get; set; }

        public Guid? BranchManager { get; set; }
    }
}