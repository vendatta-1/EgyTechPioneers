using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class QuestionBankDetailDto
    {
        public Guid? QuestionBankMasterId { get; set; }
        public int? AnswerNo { get; set; }
        public string AnswerNameL1 { get; set; } = null!;
        public string? AnswerNameL2 { get; set; }
    }

}
