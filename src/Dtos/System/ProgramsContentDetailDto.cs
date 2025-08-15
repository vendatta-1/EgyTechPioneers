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
        [Required]
        public Guid ProgramsContentMasterId { get; set; }

        public IFormFile? SessionTasksFile { get; set; }

        public IFormFile? SessionProjectFile { get; set; }

        public IFormFile? ScientificMaterialFile { get; set; }

        [Url(ErrorMessage = "Ensure it a valid link")]
        public string? SessionVideo { get; set; }

        public IFormFile? SessionQuiz { get; set; }
        
        [StringLength(500, MinimumLength = 3)]
        public string? Description { get; set; }
    }

}
