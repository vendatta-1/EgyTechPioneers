using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;
using Entities.Models.BasicInformation;
using Entities.Models.System;

namespace Entities.Models.Complaints;

public class ComplaintsStudent : Entity
{

    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ComplaintsNo { get; set; }

    public Guid? ComplaintsTypeId { get; set; }

    public Guid? ComplaintsStatusesId { get; set; }

    public Guid? StudentsDataId { get; set; }

    public DateOnly? Date { get; set; }
    [MaxLength(1000)]
    [Required]
    public string Description { get; set; }

    [MaxLength(2023)]
    public string? FilesAttach { get; set; }

    public virtual BranchData BranchesData { get; set; }

    public virtual ComplaintsStatus ComplaintsStatuses { get; set; }

    public virtual ComplaintsType ComplaintsType { get; set; }

    public virtual StudentData StudentsData { get; set; }
}