
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public  class ProjectsMaster : Entity
{ 
    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectNo { get; set; }

    public string ProjectNameL1 { get; set; } = null!;

    public string ProjectNameL2 { get; set; } = null!;

    public DateOnly? ProjectStart { get; set; }

    public DateOnly? ProjectEnd { get; set; }

    public string? ProjectResources { get; set; }

    public string? ProjectFile { get; set; }

    public string? Description { get; set; }

    public virtual AcademyData AcademyData { get; set; }

    public virtual BrancheData BranchesData { get; set; }

    public virtual ICollection<ProjectsDetail> ProjectsDetails { get; set; } = new List<ProjectsDetail>();
}