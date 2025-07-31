
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public partial class QuestionBankDetail : Entity
{
 
    public Guid? QuestionBankMasterId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AnswerNo { get; set; }

    public string AnswerNameL1 { get; set; } = null!;

    public string? AnswerNameL2 { get; set; }

    public virtual QuestionBankMaster QuestionBankMaster { get; set; }
}