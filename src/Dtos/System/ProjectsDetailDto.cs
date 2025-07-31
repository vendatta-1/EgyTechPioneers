using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class ProjectsDetailDto
    {
        public Guid? ProjectsMasterId { get; set; }

        public string ProjectNameL1 { get; set; }

        public string? ProjectNameL2 { get; set; }

        public string? Description { get; set; }
    }

}
