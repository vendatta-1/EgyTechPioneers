 
using Common;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public class ProgramsDetail: Entity
{ 

    public Guid? ProjectsDetailsId { get; set; }

    public int ProgramNo { get; set; }

    public string ProgramNameL1 { get; set; } = null!;

    public string ProgramNameL2 { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<ProgramsContentMaster> ProgramsContentMasters { get; set; } = new List<ProgramsContentMaster>();

    public virtual ProjectsDetail ProjectsDetails { get; set; }

    public virtual ICollection<QuestionBankMaster> QuestionBankMasters { get; set; } = new List<QuestionBankMaster>();
}