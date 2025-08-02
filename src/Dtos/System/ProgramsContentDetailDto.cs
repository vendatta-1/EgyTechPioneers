using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class ProgramsContentDetailDto
    {
        public Guid? Id { get; set; }
        public Guid? ProgramsContentMasterId { get; set; }

        public IFormFile? SessionTasks { get; set; }

        public IFormFile? SessionProject { get; set; }

        public IFormFile? ScientificMaterial { get; set; }

        [Url(ErrorMessage = "Ensure it a valid link")]
        public string? SessionVideo { get; set; }

        public IFormFile? SessionQuiz { get; set; }
        
        [StringLength(500, MinimumLength = 10)]
        public string? Description { get; set; }
    }

}
