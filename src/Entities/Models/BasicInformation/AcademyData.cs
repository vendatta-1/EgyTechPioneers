
using System;
using System.Collections.Generic;
using Common;
using Entities.Models.System;

namespace Entities.Models;

public class AcademyData : Entity
{ 
    public string AcademyNameL1 { get; set; }

    public string AcademyNameL2 { get; set; }

    public Guid? CountryCodeId { get; set; }

    public Guid? GovernorateCodeId { get; set; }

    public Guid? CityCodeId { get; set; }

    public string AcademyAddress { get; set; }

    public string Location { get; set; }

    public string AcademyMobil { get; set; }

    public string AcademyPhone { get; set; }

    public string AcademyWhatsapp { get; set; }

    public string AcademyEmail { get; set; }

    public string AcademyWebSite { get; set; }

    public string AcademyFacebook { get; set; }

    public string AcademyInstagram { get; set; }

    public string AcademyTiktok { get; set; }

    public string AcademyTwitter { get; set; }

    public string AcademySnapchat { get; set; }

    public string AcademyYoutube { get; set; }

    public string TaxRegistrationNumber { get; set; }

    public string TaxesErrand { get; set; }

    public string CommercialRegisterNumber { get; set; }

    public string Description { get; set; }

    public string? ImageUrl { get; set; }

    public string? AttachFiles { get; set; }


    public virtual ICollection<BranchData> BranchesData { get; set; } = new List<BranchData>();

    public virtual ICollection<ProjectsMaster> ProjectsMasters { get; set; } = new List<ProjectsMaster>();
}