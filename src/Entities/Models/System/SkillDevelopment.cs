using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;
using Entities.Models.BasicInformation;

namespace Entities.Models.System;

public class SkillDevelopment : Entity
{
    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SkillNo { get; set; }

    [StringLength(70, MinimumLength = 2)]
    public string SkillNameL1 { get; set; } = null!;

    [StringLength(70, MinimumLength = 2)]
    public string? SkillNameL2 { get; set; }

    [StringLength(500, MinimumLength = 3)]
    public string? Description { get; set; }

    [StringLength(250, MinimumLength = 20)]
    public string? LinkVideo { get; set; }

    [StringLength(250)]
    public string? FilesAttach { get; set; }
    public virtual BranchData BranchesData { get; set; }
}