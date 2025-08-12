using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace Entities.Models.System;

public partial class QuestionBankDetail : Entity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AnswerNo { get; set; }

    public Guid? QuestionBankMasterId { get; set; }

    [Required]
    [StringLength(70, MinimumLength = 1)]
    public string AnswerNameL1 { get; set; } = null!;

    [StringLength(70, MinimumLength = 1)]
    public string? AnswerNameL2 { get; set; }

    public virtual QuestionBankMaster? QuestionBankMaster { get; set; }
}