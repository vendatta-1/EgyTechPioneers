using System.ComponentModel.DataAnnotations;
using Common;

namespace Entities.Models.System;

public class ProgramsContentDetail : Entity
{
 

    public Guid? ProgramsContentMasterId { get; set; }

    [MaxLength(250)]
    public string? SessionTasks { get; set; } 

    [MaxLength(250)]
    public string? SessionProject { get; set; }  

    [MaxLength(250)]
    public string? ScientificMaterial { get; set; }  

    [MaxLength(255)]
    public string? SessionVideo { get; set; } 

    [MaxLength(255)]
    public string? SessionQuiz { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public virtual ProgramsContentMaster ProgramsContentMaster { get; set; }

    public virtual ICollection<StudentContentDetail> StudentContentDetails { get; set; } = new List<StudentContentDetail>();
}