using System.ComponentModel.DataAnnotations;
using Common;
using Entities.Models.System;

namespace Entities.Models.BasicInformation
{
    public class AcademyData : Entity
    {
        [Required, MaxLength(100)]
        public string AcademyNameL1 { get; set; }

        [Required, MaxLength(100)]
        public string AcademyNameL2 { get; set; }

        public Guid? CountryCodeId { get; set; }
        public Guid? GovernorateCodeId { get; set; }
        public Guid? CityCodeId { get; set; }

        [Required, MaxLength(200)]
        public string AcademyAddress { get; set; }

        [Required, MaxLength(100)]
        public string Location { get; set; }

        [Required, MaxLength(20)]
        public string AcademyMobil { get; set; }

        [Required, MaxLength(20)]
        public string AcademyPhone { get; set; }

        [MaxLength(20)]
        public string? AcademyWhatsapp { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string AcademyEmail { get; set; }

        [Required, Url, MaxLength(2084)]
        public string AcademyWebSite { get; set; }

        [Url, MaxLength(2084)]
        public string? AcademyFacebook { get; set; }

        [Url, MaxLength(2084)]
        public string? AcademyInstagram { get; set; }

        [Url, MaxLength(2084)]
        public string? AcademyTiktok { get; set; }

        [Url, MaxLength(2084)]
        public string? AcademyTwitter { get; set; }

        [Url, MaxLength(2084)]
        public string? AcademySnapchat { get; set; }

        [Url, MaxLength(2084)]
        public string? AcademyYoutube { get; set; }

        [Required, MaxLength(10)]
        public string TaxRegistrationNumber { get; set; }

        [Required, MaxLength(50)]
        public string TaxesErrand { get; set; }

        [Required, MaxLength(50)]
        public string CommercialRegisterNumber { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Url, MaxLength(2084)]
        public string? ImageUrl { get; set; }

        [Url, MaxLength(2084)]
        public string? AttachFiles { get; set; }

        public virtual ICollection<BranchData> BranchesData { get; set; } = new List<BranchData>();
        public virtual ICollection<ProjectsMaster> ProjectsMasters { get; set; } = new List<ProjectsMaster>();
    }
}
