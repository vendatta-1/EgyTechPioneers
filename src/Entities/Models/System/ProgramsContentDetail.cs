using Common;

namespace Entities.Models.System;

public class ProgramsContentDetail : Entity
{
 

    public Guid? ProgramsContentMasterId { get; set; }

    public string? SessionTasks { get; set; } 

    public string? SessionProject { get; set; }  

    public string? ScientificMaterial { get; set; }  

    public string? SessionVideo { get; set; } 

    public string? SessionQuiz { get; set; }

    public string? Description { get; set; }

    public virtual ProgramsContentMaster ProgramsContentMaster { get; set; }

    public virtual ICollection<StudentContentDetail> StudentContentDetails { get; set; } = new List<StudentContentDetail>();
}