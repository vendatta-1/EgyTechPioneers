using System.ComponentModel.DataAnnotations;
using Common;

namespace Entities.Models.BasicInformation;

public class AcademyClaseMaster : Entity
{
    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    public Guid? GovernorateCodeId { get; set; }

    public Guid? CityCodeId { get; set; }

    [Required, MaxLength(100)]
    public string ClaseNameL1 { get; set; }

    [Required, MaxLength(100)]
    public string? ClaseNameL2 { get; set; }

    [Required, MaxLength(200)]
    public string ClaseAddress { get; set; }

    [Required, MaxLength(100)]
    public string Location { get; set; }

    [Required, MaxLength(100)]
    public string ClaseOwnerName { get; set; }

    [Required, MaxLength(20)]
    public string OwnerMobil { get; set; }

    [MaxLength(100)]
    public string? CommunicationsOfficer { get; set; }

    [MaxLength(20)]
    public string? CommunicationsMobil { get; set; }

    [Required, EmailAddress, MaxLength(150)]
    public string EmailClase { get; set; }

    [Required, EmailAddress, MaxLength(150)]
    public string EmailOwner { get; set; }

    
    public int? ClaseBranchNo { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    public virtual ICollection<AcademyClaseDetail> AcademyClaseDetails { get; set; } = new List<AcademyClaseDetail>();

    public virtual BranchData BranchesData { get; set; }

    public virtual CityCode CityCode { get; set; }

    public virtual GovernorateCode GovernorateCode { get; set; }
}