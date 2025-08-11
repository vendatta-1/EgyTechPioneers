using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Dtos.System
{
    public class EduContactResultDto
    {
        public Guid? AcademyDataId { get; set; }

        public Guid? StudentDataId { get; set; }

        public Guid? ReasonsRejectionId { get; set; }

        public DateTime? DateResult { get; set; }

        [StringLength(500, MinimumLength = 10)]
        public string? Description { get; set; }

        public IFormFile? Attachment { get; set; } 
    }
}