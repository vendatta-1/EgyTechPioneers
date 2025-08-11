using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class ProjectsDetailDto
    {
        public Guid? Id { get; set; }
        public Guid? ProjectsMasterId { get; set; }

        [StringLength(70, MinimumLength = 3)]
        public string ProjectNameL1 { get; set; }

        [StringLength(70, MinimumLength = 3)]
        public string? ProjectNameL2 { get; set; }

        [StringLength(500, MinimumLength = 10)]
        public string? Description { get; set; }
    }

}
