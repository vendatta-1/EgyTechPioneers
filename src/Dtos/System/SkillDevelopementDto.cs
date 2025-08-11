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
        
        public Guid? AcademyDataId { get; set; }
        
        public Guid? BranchesDataId { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillNo { get; set; }
        [StringLength(70,  MinimumLength = 3)]
        public string SkillNameL1 { get; set; } = null!;
        [StringLength(70, MinimumLength = 3)]
        public string? SkillNameL2 { get; set; }
        [StringLength(500, MinimumLength = 10)]
        public string? Description { get; set; }
        [StringLength(250)]
        public string? LinkVideo { get; set; }
        public IFormFile? AttachedFiles { get; set; }
      
    }

}
