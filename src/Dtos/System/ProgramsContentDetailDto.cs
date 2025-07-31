using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class ProgramsContentDetailDto
    {
        public Guid? ProgramsContentMasterId { get; set; }

        public IFormFile? SessionTasks { get; set; }

        public IFormFile? SessionProject { get; set; }

        public IFormFile? ScientificMaterial { get; set; }

        public string? SessionVideo { get; set; }

        public IFormFile? SessionQuiz { get; set; }

        public string? Description { get; set; }
    }

}
