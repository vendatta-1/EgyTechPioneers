using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace Entities.Models.System;

public class ProgramsContentMaster : Entity
{


    public Guid? ProgramsDetailsId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SessionNo { get; set; }

    public string SessionNameL1 { get; set; } = null!;

    public string SessionNameL2 { get; set; } = null!;

    public string? ScientificMaterial { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ProgramsContentDetail> ProgramsContentDetails { get; set; } = new List<ProgramsContentDetail>();

    public virtual ProgramsDetail ProgramsDetails { get; set; }
}