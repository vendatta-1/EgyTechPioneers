using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class ProgramsDetailDto
    {
        public Guid? Id { get; set; }
        public Guid? ProjectsDetailsId { get; set; }
        [Required]
        [StringLength(70, MinimumLength = 2)]

        public string ProgramNameL1 { get; set; }

        [StringLength(70, MinimumLength = 2)]
        public string? ProgramNameL2 { get; set; }

        [StringLength(500, MinimumLength = 10)]
        public string? Description { get; set; }
    }

}
