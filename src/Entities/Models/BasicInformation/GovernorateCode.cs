using System.ComponentModel.DataAnnotations;
using Common;
using Entities.Models.System;

namespace Entities.Models.BasicInformation;

public class GovernorateCode : Entity
{ 

    public Guid CountryCodeId { get; set; }

    [MaxLength(100)]
    public string GovernorateNameL1 { get; set; } = null!;

    [MaxLength(100)]
    public string GovernorateNameL2 { get; set; } = null!;

    public virtual ICollection<AcademyClaseMaster> AcademyClaseMasters { get; set; } = new List<AcademyClaseMaster>();

    public virtual ICollection<BranchData> BranchesData { get; set; } = new List<BranchData>();

    public virtual ICollection<CityCode> CityCodes { get; set; } = new List<CityCode>();

    public virtual CountryCode CountryCode { get; set; }

    public virtual ICollection<StudentData> StudentDataGovernorateCodes { get; set; } = new List<StudentData>();

    public virtual ICollection<StudentData> StudentDataTrainingGovernorates { get; set; } = new List<StudentData>();

    public virtual ICollection<TeacherData> TeacherData { get; set; } = new List<TeacherData>();
}