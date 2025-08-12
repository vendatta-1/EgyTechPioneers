using System.ComponentModel.DataAnnotations.Schema;
using Common;
using Entities.Models.System;

namespace Entities.Models.BasicInformation;

public  class AcademyClaseDetail : Entity
{ 

    public Guid? AcademyClaseMasterId { get; set; }

    public Guid? AcademyClaseTypeId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClaseNumber { get; set; }

    public string? ImageUrl { get; set; }

    public virtual AcademyClaseMaster AcademyClaseMaster { get; set; }

    public virtual ICollection<StudentData> StudentData { get; set; } = new List<StudentData>();

    public virtual ICollection<StudentGroup> StudentGroups { get; set; } = new List<StudentGroup>();
}