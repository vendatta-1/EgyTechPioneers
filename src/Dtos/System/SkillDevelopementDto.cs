using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Dtos.System
{
    public class SkillDevelopmentDto
    {
        public Guid? Id { get; set; }
        
        [Required]
        public Guid AcademyDataId { get; set; }
        
        [Required]
        public Guid BranchesDataId { get; set; }
         
        public int? SkillNo { get; set; }
        
        [StringLength(70,  MinimumLength = 1), Required]
        public string SkillNameL1 { get; set; } = null!;
        
        [StringLength(70, MinimumLength = 1)]
        public string? SkillNameL2 { get; set; }
        
        [StringLength(500, MinimumLength = 10)]
        public string? Description { get; set; }
        
        
        [Url]
        public string? LinkVideo { get; set; }
        
        public IFormFile? AttachedFiles { get; set; }
      
    }

}
