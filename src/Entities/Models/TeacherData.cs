
using Common;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public class TeacherData : Entity
{ 

    public Guid? CompanyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    public Guid? CountryCodeId { get; set; }

    public Guid? GovernorateCodeId { get; set; }

    public Guid? CityCodeId { get; set; }

    public int TeacherNo { get; set; }

    public string TeacherNameL1 { get; set; } = null!;

    public string? TeacherNameL2 { get; set; }
    public string TeacherAddress { get; set; } = null!;

    public string NationalId { get; set; } = null!;

    public DateOnly? DateStart { get; set; }

    public string TeacherMobile { get; set; } = null!;

    public string TeacherPhone { get; set; } = null!;

    public string TeacherWhatsapp { get; set; } = null!;

    public string TeacherEmail { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public DateOnly? TeacherCancel { get; set; }

    
    public virtual BrancheData BranchesData { get; set; }

    public virtual CityCode CityCode { get; set; }

    public virtual GovernorateCode GovernorateCode { get; set; }
}