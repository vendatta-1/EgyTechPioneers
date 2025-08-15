using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dtos.Complaints
{
    public class ComplaintsStudentDto
    {
        public Guid? Id { get; set; }
        public int? ComplaintsNo { get; set; }
        [Required]
        public Guid AcademyDataId { get; set; }

        [Required]
        public Guid BranchesDataId { get; set; }

        public Guid? ComplaintsTypeId { get; set; }

        public Guid? ComplaintsStatusesId { get; set; }

        [Required(ErrorMessage = "StudentId can not be null or empty")]
        public Guid StudentsDataId { get; set; }

        public DateOnly? Date { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        public IFormFile? FilesAttach { get; set; } 
    }
}