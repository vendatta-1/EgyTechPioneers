using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class QuestionBankMasterDto
    {
        public Guid? ProgramsDetailsId { get; set; }
        public int? QuestionNo { get; set; }
        public Guid? QuestionTypeId { get; set; }
        public string QuestionNameL1 { get; set; } = null!;
        public string? QuestionNameL2 { get; set; }
        public string? Description { get; set; }
    }
}
