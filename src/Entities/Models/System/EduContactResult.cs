using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace Entities.Models.System;

public  class EduContactResult : Entity
{ 

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ResultUd { get; set; }

    public Guid? AcademyDataId { get; set; }

    public Guid? StudentDataId { get; set; }

    public Guid? ReasonsRejectionId { get; set; }

    public DateTime? DateResult { get; set; }
    [MaxLength(500)]

    public string? Description { get; set; }

    [MaxLength(2023)]
    public string? Attachment { get; set; }

    
}