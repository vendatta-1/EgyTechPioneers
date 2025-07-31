
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class SkillDevelopment : Entity
{
    public Guid SkillId { get; set; }

    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SkillNo { get; set; }

    public string SkillNameL1 { get; set; } = null!;

    public string? SkillNameL2 { get; set; }

    public string? Description { get; set; }

    public string? LinkVideo { get; set; }

    public string? FilesAttach { get; set; }
    public virtual BrancheData BranchesData { get; set; }
}