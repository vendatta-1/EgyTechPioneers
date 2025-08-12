using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.BasicInformation
{
    public class AcademyClaseDetailDto
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid AcademyClaseMasterId { get; set; }

        public Guid? AcademyClaseTypeId { get; set; }

        public int? ClaseNumber { get; set; }

        public IFormFile? Image { get; set; } 
    }

}
