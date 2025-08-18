using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Constants;
using Common.CustomAttributes;

namespace Dtos.System
{
    public class ProgramsContentDetailDto
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid ProgramsContentMasterId { get; set; }

        [AllowedExtensions(FileGroupType.Documents)]
        public IFormFile? SessionTasksFile { get; set; }
        
        [AllowedExtensions(FileGroupType.SourceCode, FileGroupType.Archives)]
        public IFormFile? SessionProjectFile { get; set; }
        
        [AllowedExtensions(FileGroupType.Archives,  FileGroupType.Documents)]
        public IFormFile? ScientificMaterialFile { get; set; }

        [Url(ErrorMessage = "Ensure it a valid link")]
        public string? SessionVideo { get; set; }
        [AllowedExtensions(FileGroupType.Documents, FileGroupType.Images)]
        public IFormFile? SessionQuiz { get; set; }
        
        [StringLength(500, MinimumLength = 3)]
        public string? Description { get; set; }
    }

}
