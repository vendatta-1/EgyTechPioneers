using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;
using Entities.Models.BasicInformation;
using Entities.Models.Complaints;

namespace Entities.Models.System;

public class StudentData : Entity
{
    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StudentCode { get; set; }

    public Guid? StudentBarCode { get; set; }

    [StringLength(70, MinimumLength = 2)] public string StudentNameL1 { get; set; } = null!;

    [StringLength(70, MinimumLength = 2)] public string StudentNameL2 { get; set; } = null!;

    public Guid? CountryCodeId { get; set; }

    [ForeignKey(nameof(GovernorateCode))] public Guid? GovernorateCodeId { get; set; }

    [ForeignKey(nameof(CityCode))] public Guid? CityCodeId { get; set; }

    [StringLength(250, MinimumLength = 3)] public string StudentAddress { get; set; } = null!;

    [StringLength(12, MinimumLength = 7)] public string StudentPhone { get; set; } = null!;

    public DateTime? TrainingTime { get; set; }

    [ForeignKey(nameof(TrainingGovernorate))]
    public Guid? TrainingGovernorateId { get; set; }

    public long? RecommendTrack { get; set; }

    [StringLength(100)] public string? RecommendJobProfile { get; set; }

    [StringLength(50)] public string? GraduationStatus { get; set; }

    [StringLength(100)] public string? Track { get; set; }

    public int? ProfileCode { get; set; }

    public Guid? AcademyClaseDetailsId { get; set; }

    public Guid? StudentGroupId { get; set; }

    public Guid? ProjectsDetailsId { get; set; }

    [StringLength(222)] public string? TrainingProvider { get; set; }

    [StringLength(255)] public string? LinkedIn { get; set; }

    [StringLength(255)] public string? Facebook { get; set; }

    [StringLength(50)] public string? Language { get; set; }

    [StringLength(200)] public string? CertificateName { get; set; }

    [StringLength(12, MinimumLength = 7)] public string? StudentMobil { get; set; }

    [StringLength(12, MinimumLength = 7)] public string? StudentWhatsapp { get; set; }

    [StringLength(150)] [EmailAddress] public string? StudentEmail { get; set; }

    [StringLength(150)] [EmailAddress] public string? EmailAcademy { get; set; }

    [StringLength(50)] public string? EmailPassword { get; set; }

    public virtual AcademyClaseDetail AcademyClaseDetails { get; set; }

    public virtual BranchData BranchesData { get; set; }

    public virtual CityCode CityCode { get; set; }

    public virtual GovernorateCode GovernorateCode { get; set; }

    public virtual GovernorateCode TrainingGovernorate { get; set; }

    public virtual ProjectsDetail ProjectsDetails { get; set; }

    public virtual StudentGroup StudentGroup { get; set; }

    public virtual ICollection<ComplaintsStudent> ComplaintsStudents { get; set; } = new List<ComplaintsStudent>();

    public virtual ICollection<StudentAttend> StudentAttends { get; set; } = new List<StudentAttend>();

    public virtual ICollection<StudentContentDetail> StudentContentDetails { get; set; } =
        new List<StudentContentDetail>();

    public virtual ICollection<StudentEvaluation> StudentEvaluations { get; set; } = new List<StudentEvaluation>();
}