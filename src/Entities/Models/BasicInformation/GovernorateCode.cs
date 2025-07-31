
using Common;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public class GovernorateCode : Entity
{ 

    public Guid? CountryCodeId { get; set; }

    public string GovernorateNameL1 { get; set; } = null!;

    public string GovernorateNameL2 { get; set; } = null!;

    public virtual ICollection<AcademyClaseMaster> AcademyClaseMasters { get; set; } = new List<AcademyClaseMaster>();

    public virtual ICollection<BrancheData> BranchesData { get; set; } = new List<BrancheData>();

    public virtual ICollection<CityCode> CityCodes { get; set; } = new List<CityCode>();

    public virtual CountryCode CountryCode { get; set; }

    public virtual ICollection<StudentData> StudentDatumGovernorateCodes { get; set; } = new List<StudentData>();

    public virtual ICollection<StudentData> StudentDatumTrainingGoverorates { get; set; } = new List<StudentData>();

    public virtual ICollection<TeacherData> TeacherData { get; set; } = new List<TeacherData>();
}