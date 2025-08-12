using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class QuestionBankMasterDto
    {
        public Guid? Id { get; set; }
        
        public Guid? ProgramsDetailsId { get; set; }

        public int? QuestionNo { get; set; }
        
        [StringLength(70, MinimumLength = 1)]
        public string QuestionNameL1 { get; set; } = null!;
        
        [StringLength(70, MinimumLength = 1)]
        public string? QuestionNameL2 { get; set; }
        
        [StringLength(500, MinimumLength = 10)]
        public string? Description { get; set; }
    }
}