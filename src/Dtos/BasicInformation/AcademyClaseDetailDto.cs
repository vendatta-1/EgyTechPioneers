using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Constants;
using Common.CustomAttributes;

namespace Dtos.BasicInformation
{
    public class AcademyClaseDetailDto
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid AcademyClaseMasterId { get; set; }

        public Guid? AcademyClaseTypeId { get; set; }

        public int? ClaseNumber { get; set; }

        [AllowedExtensions(FileGroupType.Images)]
        public IFormFile? Image { get; set; } 
    }

}
