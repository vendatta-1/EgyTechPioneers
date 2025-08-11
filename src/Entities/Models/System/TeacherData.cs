using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace Entities.Models.System;

public class TeacherData : Entity
{
    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    public Guid? CountryCodeId { get; set; }

    public Guid? GovernorateCodeId { get; set; }

    public Guid? CityCodeId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TeacherNo { get; set; }

    [StringLength(70, MinimumLength = 3)] public string TeacherNameL1 { get; set; } = null!;
    [StringLength(70, MinimumLength = 3)] public string? TeacherNameL2 { get; set; }
    [StringLength(150, MinimumLength = 5)] public string TeacherAddress { get; set; } = null!;

    [StringLength(14, MinimumLength = 14)] public string NationalId { get; set; } = null!;

    public DateOnly? DateStart { get; set; }

    [StringLength(12, MinimumLength = 7)] public string? TeacherMobile { get; set; }
    [StringLength(12, MinimumLength = 7)] public string? TeacherPhone { get; set; } = null!;
    [StringLength(12)] public string? TeacherWhatsapp { get; set; } = null!;

    [StringLength(150)] public string? TeacherEmail { get; set; } = null!;
    [StringLength(250)] public string? ImageUrl { get; set; }
    [StringLength(500)] public string? Description { get; set; }

    public DateOnly? TeacherCancel { get; set; }


    public virtual BranchData BranchesData { get; set; }

    public virtual CityCode CityCode { get; set; }

    public virtual GovernorateCode GovernorateCode { get; set; }
}