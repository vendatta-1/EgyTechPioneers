using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace Entities.Models.System;

public class ProgramsDetail: Entity
{ 

    public Guid? ProjectsDetailsId { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProgramNo { get; set; }

    [StringLength(70)]
    public string ProgramNameL1 { get; set; } = null!;

    [StringLength(70)]
    public string ProgramNameL2 { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    public virtual ICollection<ProgramsContentMaster> ProgramsContentMasters { get; set; } = new List<ProgramsContentMaster>();

    public virtual ProjectsDetail ProjectsDetails { get; set; }

    public virtual ICollection<QuestionBankMaster> QuestionBankMasters { get; set; } = new List<QuestionBankMaster>();
}