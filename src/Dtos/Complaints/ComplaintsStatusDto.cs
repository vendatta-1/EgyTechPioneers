using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 

namespace Dtos.Complaints
{
    public class ComplaintsStatusDto
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid AcademyDataId { get; set; }

        [Required]
        public Guid BranchesDataId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string StatusesNameL1 { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string StatusesNameL2 { get; set; } = null!;
    }
}
