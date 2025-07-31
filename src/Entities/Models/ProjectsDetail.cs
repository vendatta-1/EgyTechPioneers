
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class ProjectsDetail : Entity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectDetalisNo { get; set; }

    public Guid? ProjectsMasterId { get; set; }

    public string ProjectNameL1 { get; set; } = null!;

    public string ProjectNameL2 { get; set; } = null!;

    public string? Description { get; set; }
    public virtual ICollection<ProgramsDetail> ProgramsDetails { get; set; } = new List<ProgramsDetail>();

    public virtual ProjectsMaster ProjectsMaster { get; set; }

    public virtual ICollection<StudentData> StudentData { get; set; } = new List<StudentData>();
}