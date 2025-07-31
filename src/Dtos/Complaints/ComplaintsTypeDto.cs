using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Complaints
{
    public class ComplaintsTypeDto
    {
        public Guid? CompanyDataId { get; set; }

        public Guid? BranchesDataId { get; set; }

        public string TypeNameL1 { get; set; } = null!;

        public string TypeNameL2 { get; set; } = null!;
    }
}
