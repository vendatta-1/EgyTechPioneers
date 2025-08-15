using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dtos.BasicInformation
{
    public class AcademyJobDto
    {
        public Guid? Id { get; set; }
        public int? JobNo { get; set; }

        [Required]
        public Guid AcademyDataId { get; set; }

        [Required]
        public Guid BranchesDataId { get; set; }

        [Required]
        [StringLength(70, MinimumLength = 2)]
        public string JobNameL1 { get; set; }

        [StringLength(70)]
        public string? JobNameL2 { get; set; }

        [StringLength(500), Required] 
        public string Description { get; set; }

        [StringLength(2084)]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string JobLink { get; set; }
    }
}