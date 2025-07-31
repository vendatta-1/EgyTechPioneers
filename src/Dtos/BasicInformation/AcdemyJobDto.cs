using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.BasicInformation
{
    public class AcademyJobDto
    {
        public int JobNo { get; set; }

        public Guid? AcademyDataId { get; set; }

        public Guid? BranchesDataId { get; set; }

        public string JobNameL1 { get; set; }

        public string? JobNameL2 { get; set; }

        public string Description { get; set; }

        public IFormFile? JobFile { get; set; }
    }

}
