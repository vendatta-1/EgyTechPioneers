using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class TeacherDataDto
    {
        public Guid? CompanyDataId { get; set; }

        public Guid? BranchesDataId { get; set; }

        public Guid? CountryCodeId { get; set; }

        public Guid? GovernorateCodeId { get; set; }

        public Guid? CityCodeId { get; set; }

        public string TeacherNameL1 { get; set; }

        public string? TeacherNameL2 { get; set; }

        public string TeacherAddress { get; set; }

        public string NationalId { get; set; }

        public DateOnly? DateStart { get; set; }

        public string TeacherMobile { get; set; }

        public string TeacherPhone { get; set; }

        public string TeacherWhatsapp { get; set; }

        public string TeacherEmail { get; set; }

        public IFormFile? Image { get; set; }

        public string? Description { get; set; }

        public DateOnly? TeacherCancel { get; set; }
    }

}
