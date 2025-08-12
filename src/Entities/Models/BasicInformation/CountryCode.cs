using System.ComponentModel.DataAnnotations;
using Common;

namespace Entities.Models.BasicInformation;

public class CountryCode: Entity
{ 

    [MaxLength(100)]
    public string CountryNameL1 { get; set; } = null!;

    [MaxLength(100)]
    public string CountryNameL2 { get; set; } = null!;

    public virtual ICollection<BranchData> BranchesData { get; set; } = new List<BranchData>();

    public virtual ICollection<GovernorateCode> GovernorateCodes { get; set; } = new List<GovernorateCode>();
}