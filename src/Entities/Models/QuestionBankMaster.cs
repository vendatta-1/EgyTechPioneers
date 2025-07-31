
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class QuestionBankMaster : Entity
{ 

    public Guid? ProgramsDetailsId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int QuestionNo { get; set; }

    public Guid? QuestionTypeId { get; set; }

    public string QuestionNameL1 { get; set; } = null!;

    public string? QuestionNameL2 { get; set; }

    public string? Description { get; set; }

    public virtual ProgramsDetail ProgramsDetails { get; set; }

    public virtual ICollection<QuestionBankDetail> QuestionBankDetails { get; set; } = new List<QuestionBankDetail>();
}