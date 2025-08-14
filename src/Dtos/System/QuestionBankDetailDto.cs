using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class QuestionBankDetailDto
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid QuestionBankMasterId { get; set; }
        
        [StringLength(70 , MinimumLength = 1)]
        public string AnswerNameL1 { get; set; } = null!;
        
        [StringLength(70 , MinimumLength = 1)]
        public string  AnswerNameL2 { get; set; }
    }

}
