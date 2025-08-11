using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.BasicInformation
{
    
    public class AcademyClaseMasterDto
    {
        public Guid? Id { get; set; }
        
        public Guid? AcademyDataId { get; set; }

        public Guid? BranchesDataId { get; set; }

        public Guid? GovernorateCodeId { get; set; }

        public Guid? CityCodeId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ClaseNameL1 { get; set; }

        [StringLength(50)]
        public string? ClaseNameL2 { get; set; }

        [Required]
        [StringLength(150)]
        public string ClaseAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        [StringLength(50)]
        public string ClaseOwnerName { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string OwnerMobil { get; set; }

        [Required]
        [StringLength(50)]
        public string CommunicationsOfficer { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string CommunicationsMobil { get; set; }

        [Required]
        [EmailAddress]
        public string EmailClase { get; set; }

        [Required]
        [EmailAddress]
        public string EmailOwner { get; set; }

        public int? ClaseBranchNo { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
   

}
