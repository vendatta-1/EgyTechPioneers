using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class ProgramsContentMasterDto
    {
        public Guid? ProgramsDetailsId { get; set; }

        public int SessionNo { get; set; }

        public string SessionNameL1 { get; set; }

        public string? SessionNameL2 { get; set; }

        public IFormFile? ScientificMaterial { get; set; }

        public string? Description { get; set; }
    }

}
