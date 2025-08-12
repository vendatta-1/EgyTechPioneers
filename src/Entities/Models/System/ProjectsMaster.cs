using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;
using Entities.Models.BasicInformation;

namespace Entities.Models.System;

public class ProjectsMaster : Entity
{
    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectNo { get; set; }

    [Required]
    [StringLength(70, MinimumLength = 2)]
    public string ProjectNameL1 { get; set; } = null!;

    [StringLength(70, MinimumLength = 2)]
    public string ProjectNameL2 { get; set; } = null!;

    public DateOnly? ProjectStart { get; set; }

    public DateOnly? ProjectEnd { get; set; }

    [StringLength(250)]
    public string? ProjectResources { get; set; }

    [StringLength(250)]
    public string? ProjectFile { get; set; }

    [StringLength(500, MinimumLength = 3)]
    public string? Description { get; set; }

    public virtual AcademyData AcademyData { get; set; }
    public virtual BranchData BranchesData { get; set; }
    public virtual ICollection<ProjectsDetail> ProjectsDetails { get; set; } = new List<ProjectsDetail>();
}