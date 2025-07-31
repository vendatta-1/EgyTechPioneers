 
using Common;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public class ComplaintsStatus : Entity
{
 
    public Guid? CompanyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    public string StatusesNameL1 { get; set; } = null!;

    public string StatusesNameL2 { get; set; } = null!;
 
    public virtual ICollection<ComplaintsStudent> ComplaintsStudents { get; set; } = new List<ComplaintsStudent>();
}