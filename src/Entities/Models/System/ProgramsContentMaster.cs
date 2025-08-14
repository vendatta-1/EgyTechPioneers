using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace Entities.Models.System;

public class ProgramsContentMaster : Entity
{


    public Guid? ProgramsDetailsId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SessionNo { get; set; }

    [MaxLength(70)]
    public string SessionNameL1 { get; set; } = null!;
    [MaxLength(70)]

    public string? SessionNameL2 { get; set; } = null!;
    [MaxLength(250)]

    public string? ScientificMaterial { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public virtual ICollection<ProgramsContentDetail> ProgramsContentDetails { get; set; } = new List<ProgramsContentDetail>();

    public virtual ProgramsDetail ProgramsDetails { get; set; }
}