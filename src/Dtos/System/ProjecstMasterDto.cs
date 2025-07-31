using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class ProjectsMasterDto
    {
        public Guid? AcademyDataId { get; set; }

        public Guid? BranchesDataId { get; set; }

        public string ProjectNameL1 { get; set; }

        public string? ProjectNameL2 { get; set; }

        public DateOnly? ProjectStart { get; set; }

        public DateOnly? ProjectEnd { get; set; }

        public IFormFile? ProjectResources { get; set; }

        public IFormFile? ProjectFile { get; set; }

        public string? Description { get; set; }
    }

}
