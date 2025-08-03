using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Dtos.System;

public class StudentDataDto
{
    public Guid? Id { get; set; }

    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    public int? StudentCode { get; set; }

    public Guid? StudentBarCode { get; set; }

    [Required]
    [StringLength(70, MinimumLength = 3)]
    public string StudentNameL1 { get; set; } = null!;

    [Required]
    [StringLength(70, MinimumLength = 3)]
    public string StudentNameL2 { get; set; } = null!;

    public Guid? CountryCodeId { get; set; }

    public Guid? GovernorateCodeId { get; set; }

    public Guid? CityCodeId { get; set; }

    [Required]
    [StringLength(250, MinimumLength = 3)]
    public string StudentAddress { get; set; } = null!;

    [Required]
    [StringLength(12, MinimumLength = 7)]
    public string StudentPhone { get; set; } = null!;

    public DateTime? TrainingTime { get; set; }

    public Guid? TrainingGovernorateId { get; set; }

    public long? RecommendTrack { get; set; }

    [StringLength(100)]
    public string? RecommendJobProfile { get; set; }

    [StringLength(50)]
    public string? GraduationStatus { get; set; }

    [StringLength(100)]
    public string? Track { get; set; }

    public int? ProfileCode { get; set; }

    public Guid? AcademyClaseDetailsId { get; set; }

    public Guid? StudentGroupId { get; set; }

    public Guid? ProjectsDetailsId { get; set; }

    [StringLength(100)]
    public string? TrainingProvider { get; set; }

    [StringLength(100)]
    public string? LinkedIn { get; set; }

    [StringLength(100)]
    public string? Facebook { get; set; }

    [StringLength(50)]
    public string? Language { get; set; }

    [StringLength(100)]
    public string? CertificateName { get; set; }

    [StringLength(12, MinimumLength = 7)]
    public string? StudentMobil { get; set; }

    [StringLength(12, MinimumLength = 7)]
    public string? StudentWhatsapp { get; set; }

    [StringLength(150)]
    [EmailAddress]
    public string? StudentEmail { get; set; }

    [StringLength(150)]
    [EmailAddress]
    public string? EmailAcademy { get; set; }

    [StringLength(50)]
    public string? EmailPassword { get; set; }
}
