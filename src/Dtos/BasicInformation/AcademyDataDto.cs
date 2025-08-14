using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dtos.BasicInformation
{
    public class AcademyDataDto
    {
        public Guid? Id { get; set; }
        [Required, StringLength(100)]
        public string AcademyNameL1 { get; set; }

        [StringLength(100)]
        [Required]
        public string AcademyNameL2 { get; set; }

        public Guid? CountryCodeId { get; set; }
        public Guid? GovernorateCodeId { get; set; }
        public Guid? CityCodeId { get; set; }

        [Required, StringLength(200)]
        public string AcademyAddress { get; set; }

        [Required, StringLength(200)]
        public string Location { get; set; }

        [Required, Phone, StringLength(20)]
        public string AcademyMobil { get; set; }

        [Phone, StringLength(20)]
        public string AcademyPhone { get; set; }

        [Phone, StringLength(20)]
        public string AcademyWhatsapp { get; set; }

        [Required, EmailAddress]
        public string AcademyEmail { get; set; }

        [Url]
        public string AcademyWebSite { get; set; }

        [Url]
        public string? AcademyFacebook { get; set; }

        [Url]
        public string? AcademyInstagram { get; set; }

        [Url]
        public string? AcademyTiktok { get; set; }

        [Url]
        public string? AcademyTwitter { get; set; }

        [Url]
        public string? AcademySnapchat { get; set; }

        [Url]
        public string? AcademyYoutube { get; set; }

        [Required, StringLength(50)]
        public string TaxRegistrationNumber { get; set; }

        [Required, StringLength(100)]
        public string TaxesErrand { get; set; }

        [Required, StringLength(50)]
        public string CommercialRegisterNumber { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public IFormFile? Image { get; set; } 
        public IFormFile? Attachments { get; set; } 
    }
}