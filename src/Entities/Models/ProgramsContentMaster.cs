
using Common;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public class ProgramsContentMaster : Entity
{


    public Guid? ProgramsDetailsId { get; set; }

    public int SessionNo { get; set; }

    public string SessionNameL1 { get; set; } = null!;

    public string SessionNameL2 { get; set; } = null!;

    public string? ScientificMaterial { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ProgramsContentDetail> ProgramsContentDetails { get; set; } = new List<ProgramsContentDetail>();

    public virtual ProgramsDetail ProgramsDetails { get; set; }
}