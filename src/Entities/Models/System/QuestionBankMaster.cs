using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace Entities.Models.System;

public class QuestionBankMaster : Entity
{ 

    public Guid? ProgramsDetailsId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int QuestionNo { get; set; }

    // public Guid? QuestionTypeId { get; set; }

    [StringLength(70 , MinimumLength = 3)]
    public string QuestionNameL1 { get; set; } = null!;

    [StringLength(70 , MinimumLength = 3)]
    public string? QuestionNameL2 { get; set; }

    [StringLength(500 , MinimumLength = 10)]
    public string? Description { get; set; }

    public virtual ProgramsDetail ProgramsDetails { get; set; }

    public virtual ICollection<QuestionBankDetail> QuestionBankDetails { get; set; } = new HashSet<QuestionBankDetail>();
}