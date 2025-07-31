using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Dtos.System
{
    public class SkillDevelopmentDto
    {
        public Guid SkillId { get; set; }
        public Guid? AcademyDataId { get; set; }
        public Guid? BranchesDataId { get; set; }
        public int SkillNo { get; set; }
        public string SkillNameL1 { get; set; } = null!;
        public string? SkillNameL2 { get; set; }
        public string? Description { get; set; }
        public string? LinkVideo { get; set; }
        public IFormFile? FilesAttach { get; set; }
    }

}
