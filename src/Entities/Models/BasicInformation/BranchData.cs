using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;
using Entities.Models.Complaints;
using Entities.Models.System;

namespace Entities.Models.BasicInformation;

public class BranchData : Entity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BranchesDataId { get; set; }

    public Guid? AcademyDataId { get; set; }

    [Required, MaxLength(100)]
    public string BranchNameL1 { get; set; }

    [Required, MaxLength(100)]
    public string? BranchNameL2 { get; set; }

    public Guid? CountryCodeId { get; set; }

    public Guid? GovernorateCodeId { get; set; }

    public Guid? CityCodeId { get; set; }

    [Required, MaxLength(200)]
    public string BranchAddress { get; set; }

    [Required, MaxLength(20)]
    public string BranchMobile { get; set; }

    [MaxLength(20)]
    public string? BranchPhone { get; set; }

    [MaxLength(20)]
    public string? BranchWhatsapp { get; set; }

    [Required, EmailAddress, MaxLength(150)]
    public string BranchEmail { get; set; }

    public Guid? BranchManager { get; set; }

    public virtual AcademyData AcademyData { get; set; }

    public virtual CountryCode CountryCode { get; set; }

    public virtual GovernorateCode GovernorateCode { get; set; }

    public virtual CityCode CityCode { get; set; }

    public virtual ICollection<AcademyClaseMaster> AcademyClaseMasters { get; set; }  

    public virtual ICollection<AcademyJob> AcademyJobs { get; set; } 

    public virtual ICollection<ComplaintsStudent> ComplaintsStudents { get; set; }  

    public virtual ICollection<ProjectsMaster> ProjectsMasters { get; set; }  

    public virtual ICollection<SkillDevelopment> SkillDevelopments { get; set; }  

    public virtual ICollection<StudentData> StudentData { get; set; }  

    public virtual ICollection<StudentGroup> StudentGroups { get; set; }  

    public virtual ICollection<TeacherData> TeacherData { get; set; }  
}
