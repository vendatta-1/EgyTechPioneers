
using Common;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public  class AcademyJob : Entity
{ 

    public int JobNo { get; set; }

    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    public string JobNameL1 { get; set; }

    public string JobNameL2 { get; set; }

    public string Description { get; set; }

    public string JobLink { get; set; }

    public virtual BranchData BranchesData { get; set; }
}