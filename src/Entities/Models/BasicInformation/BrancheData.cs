 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class BrancheData
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BranchesDataId { get; set; } //usage??

    public Guid? AcademyDataId { get; set; }

    public string BranchNameL1 { get; set; }

    public string BranchNameL2 { get; set; }

    public Guid? CountryCodeId { get; set; }

    public Guid? GovernorateCodeId { get; set; }

    public Guid? CityCodeId { get; set; }

    public string BranchAddress { get; set; }

    public string BranchMobile { get; set; }

    public string BranchPhone { get; set; }

    public string BranchWhatsapp { get; set; }

    public string BranchEmail { get; set; }

    public Guid? BranchManager { get; set; }
    public virtual ICollection<AcademyClaseMaster> AcademyClaseMasters { get; set; } = new List<AcademyClaseMaster>();

    public virtual AcademyData AcademyData { get; set; }

    public virtual ICollection<AcademyJob> AcademyJobs { get; set; } = new List<AcademyJob>();

    public virtual CityCode CityCode { get; set; }

    public virtual ICollection<ComplaintsStudent> ComplaintsStudents { get; set; } = new List<ComplaintsStudent>();

    public virtual CountryCode CountryCode { get; set; }

    public virtual GovernorateCode GovernorateCode { get; set; }

    public virtual ICollection<ProjectsMaster> ProjectsMasters { get; set; } = new List<ProjectsMaster>();

    public virtual ICollection<SkillDevelopment> SkillDevelopments { get; set; } = new List<SkillDevelopment>();

    public virtual ICollection<StudentData> StudentData { get; set; } = new List<StudentData>();

    public virtual ICollection<StudentGroup> StudentGroups { get; set; } = new List<StudentGroup>();

    public virtual ICollection<TeacherData> TeacherData { get; set; } = new List<TeacherData>();
}