using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class ProgramsDetailDto
    {
        public Guid? ProjectsDetailsId { get; set; }

        public string ProgramNameL1 { get; set; }

        public string? ProgramNameL2 { get; set; }

        public string? Description { get; set; }
    }

}
