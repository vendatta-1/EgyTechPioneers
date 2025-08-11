using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace Entities.Models.System;

public class ProjectsDetail : Entity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectDetailsNo { get; set; }

    public Guid? ProjectsMasterId { get; set; }

    [Required]
    [StringLength(70, MinimumLength = 3)]
    public string ProjectNameL1 { get; set; } = null!;

    [StringLength(70, MinimumLength = 3)]
    public string ProjectNameL2 { get; set; } = null!;

    [StringLength(500, MinimumLength = 10)]
    public string? Description { get; set; }

    public virtual ProjectsMaster ProjectsMaster { get; set; }

    public virtual ICollection<ProgramsDetail> ProgramsDetails { get; set; }  =new HashSet<ProgramsDetail>();

    public virtual ICollection<StudentData> StudentData { get; set; }  = new HashSet<StudentData>();
}
