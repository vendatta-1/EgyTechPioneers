using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.BasicInformation
{
    public class GovernorateCodeDto
    {
        public Guid? CountryCodeId { get; set; }

        public string GovernorateNameL1 { get; set; } = null!;

        public string GovernorateNameL2 { get; set; } = null!;
    }
}
