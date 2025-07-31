using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class StudentDataDto
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
    }
}
