using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.BasicInformation
{
    public class BrancheDataDto
    {
        public Guid? AcademyDataId { get; set; }

        public string BranchNameL1 { get; set; }

        public string? BranchNameL2 { get; set; }

        public Guid? CountryCodeId { get; set; }

        public Guid? GovernorateCodeId { get; set; }

        public Guid? CityCodeId { get; set; }

        public string BranchAddress { get; set; }

        public string BranchMobile { get; set; }

        public string BranchPhone { get; set; }

        public string BranchWhatsapp { get; set; }

        public string BranchEmail { get; set; }

        public Guid? BranchManager { get; set; }
    }

}
