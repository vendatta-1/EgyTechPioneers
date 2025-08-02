
using Common;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public class CountryCode: Entity
{ 

    public string CountryNameL1 { get; set; } = null!;

    public string CountryNameL2 { get; set; } = null!;

    public virtual ICollection<BranchData> BranchesData { get; set; } = new List<BranchData>();

    public virtual ICollection<GovernorateCode> GovernorateCodes { get; set; } = new List<GovernorateCode>();
}