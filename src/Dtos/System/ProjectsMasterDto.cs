using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class ProjectsMasterDto
    {
        public Guid ?Id  { get; set; }
        [Required]
        
        public Guid AcademyDataId { get; set; }

        [Required]
        public Guid BranchesDataId { get; set; }

        [StringLength(70, MinimumLength = 2)]
        public string ProjectNameL1 { get; set; }

        [StringLength(70, MinimumLength = 2)]
        public string? ProjectNameL2 { get; set; }
        
        public DateOnly? ProjectStart { get; set; }

        public DateOnly? ProjectEnd { get; set; }
        public IFormFile? ProjectResources { get; set; }
        public IFormFile? ProjectFiles { get; set; }
        
        [StringLength(500, MinimumLength = 3)]
        public string? Description { get; set; }
    }

}
