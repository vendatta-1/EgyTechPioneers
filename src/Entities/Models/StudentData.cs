
using Common;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public class StudentData : Entity
{ 

    public Guid? CompanyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    public int StudentCode { get; set; }

    public Guid? StudentBarCode { get; set; }

    public string StudentNameL1 { get; set; } = null!;

    public string StudentNameL2 { get; set; } = null!;

    public Guid? CountryCodeId { get; set; }

    public Guid? GovernorateCodeId { get; set; }

    public Guid? CityCodeId { get; set; }

    public string StudentAddress { get; set; } = null!;

    public string StudentPhone { get; set; } = null!;

    public DateTime? TrainingTime { get; set; }
    public Guid? GoverorateCodeId { get; set; }

    public Guid? TrainingGoverorateId { get; set; }

    public long? RecommendTrack { get; set; }

    public string? RecommendJobProfile { get; set; }

    public string? GraduationStatus { get; set; }


    public string? Track { get; set; }

    public int? ProfileCode { get; set; }

    public Guid? AcademyClaseDetailsId { get; set; }

    public Guid? StudentGroupId { get; set; }

    public Guid? ProjectsDetailsId { get; set; }

    public string? TrainingProvider { get; set; }

    public string? LinkedIn { get; set; }

    public string? Facebook { get; set; }

    public string? Language { get; set; }

    public string? CertificateName { get; set; }

    public string? StudentMobil { get; set; }

    public string? StudentWhatsapp { get; set; }

    public string? StudentEmail { get; set; }

    public string? EmailAcademy { get; set; }

    public string? EmailPasswored { get; set; }

    public virtual AcademyClaseDetail AcademyClaseDetails { get; set; }

    public virtual BrancheData BranchesData { get; set; }

    public virtual CityCode CityCode { get; set; }

    public virtual ICollection<ComplaintsStudent> ComplaintsStudents { get; set; } = new List<ComplaintsStudent>();

    public virtual GovernorateCode GovernorateCode { get; set; }

    public virtual ProjectsDetail ProjectsDetails { get; set; }

    public virtual ICollection<StudentAttend> StudentAttends { get; set; } = new List<StudentAttend>();

    public virtual ICollection<StudentContentDetail> StudentContentDetails { get; set; } = new List<StudentContentDetail>();

    public virtual ICollection<StudentEvaluation> StudentEvaluations { get; set; } = new List<StudentEvaluation>();

    public virtual StudentGroup StudentGroup { get; set; }

    public virtual GovernorateCode TrainingGoverorate { get; set; }
}