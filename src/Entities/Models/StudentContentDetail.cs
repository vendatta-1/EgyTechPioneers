
using Common;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public class StudentContentDetail : Entity
{
 

    public Guid? ProgramsContentDetailsId { get; set; }

    public Guid? StudentDataId { get; set; }

    public string? SessionTasks { get; set; }

    public string? SessionProject { get; set; }

    public string? SessionQuiz { get; set; }

    public string? Description { get; set; }

    public virtual ProgramsContentDetail ProgramsContentDetails { get; set; }

    public virtual StudentData StudentData { get; set; }
}