using System.ComponentModel.DataAnnotations;
using Common;

namespace Entities.Models.System;

public class StudentContentDetail : Entity
{
 

    public Guid? ProgramsContentDetailsId { get; set; }

    public Guid? StudentDataId { get; set; }

    [StringLength(250, MinimumLength = 10)]
    public string? SessionTasks { get; set; }

    [StringLength(250, MinimumLength = 10)]
    public string? SessionProject { get; set; }

    [StringLength(250, MinimumLength = 10)]
    public string? SessionQuiz { get; set; }

    [StringLength(500, MinimumLength = 10)]
    public string? Description { get; set; }

    public virtual ProgramsContentDetail ProgramsContentDetails { get; set; }

    public virtual StudentData StudentData { get; set; }
}