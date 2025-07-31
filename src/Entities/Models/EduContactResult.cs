
using Common;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public  class EduContactResult : Entity
{ 

    public int ResultUd { get; set; }

    public Guid? CompanyDataId { get; set; }

    public Guid? StudentDataId { get; set; }

    public Guid? ReasonsRejectionId { get; set; }

    public DateTime? DateResult { get; set; }

    public string? Description { get; set; }

    public string? Attachment { get; set; }

    
}