using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Complaints
{
    public class ComplaintsStatusDto
    {
        public Guid? CompanyDataId { get; set; }

        public Guid? BranchesDataId { get; set; }

        public string StatusesNameL1 { get; set; } = null!;

        public string StatusesNameL2 { get; set; } = null!;
    }
}
