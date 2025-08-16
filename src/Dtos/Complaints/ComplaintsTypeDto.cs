using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Complaints
{
    public class ComplaintsTypeDto
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid AcademyDataId { get; set; }

        [Required]
        public Guid BranchesDataId { get; set; }

        [StringLength(70, MinimumLength = 3), Required]
        public string TypeNameL1 { get; set; } = null!;
        [StringLength(70, MinimumLength = 3)]
      
        public string? TypeNameL2 { get; set; } 
    }
}
