
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class CountryCode: Entity
{ 

    [MaxLength(100)]
    public string CountryNameL1 { get; set; } = null!;

    [MaxLength(100)]
    public string CountryNameL2 { get; set; } = null!;

    public virtual ICollection<BranchData> BranchesData { get; set; } = new List<BranchData>();

    public virtual ICollection<GovernorateCode> GovernorateCodes { get; set; } = new List<GovernorateCode>();
}