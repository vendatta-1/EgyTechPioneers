using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace Entities.Models.System;

public  class EduContactResult : Entity
{ 

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ResultUd { get; set; }

    public Guid? CompanyDataId { get; set; }

    public Guid? StudentDataId { get; set; }

    public Guid? ReasonsRejectionId { get; set; }

    public DateTime? DateResult { get; set; }

    public string? Description { get; set; }

    public string? Attachment { get; set; }

    
}