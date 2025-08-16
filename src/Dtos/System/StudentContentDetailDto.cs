using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Dtos.System;

public class StudentContentDetailDto
{
    public Guid? Id { get; set; }
    
    public Guid? ProgramsContentDetailsId { get; set; }

    [Required]
    public Guid StudentDataId { get; set; }

    public IFormFile? SessionTasks { get; set; }
 
    public IFormFile? SessionProject { get; set; }
 
    public IFormFile? SessionQuiz { get; set; }
  

    [StringLength(500, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 500 characters.")]
    public string? Description { get; set; }
}