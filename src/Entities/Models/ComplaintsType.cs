using Common;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public class ComplaintsType:Entity
{
 

    public Guid? CompanyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    public string TypeNameL1 { get; set; } = null!;

    public string TypeNameL2 { get; set; } = null!;

    public virtual ICollection<ComplaintsStudent> ComplaintsStudents { get; set; } = new List<ComplaintsStudent>();
}