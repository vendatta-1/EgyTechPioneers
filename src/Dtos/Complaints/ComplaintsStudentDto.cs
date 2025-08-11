using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dtos.Complaints
{
    public class ComplaintsStudentDto
    {
        public Guid? Id { get; set; }
        public int? ComplaintsNo { get; set; }
        public Guid? AcademyDataId { get; set; }

        public Guid? BranchesDataId { get; set; }

        public Guid? ComplaintsTypeId { get; set; }

        public Guid? ComplaintsStatusesId { get; set; }

        public Guid? StudentsDataId { get; set; }

        public DateOnly? Date { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; } = null!;

        public IFormFile? FilesAttach { get; set; } 
    }
}