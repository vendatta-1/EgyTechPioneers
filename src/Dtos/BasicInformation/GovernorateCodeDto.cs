using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.BasicInformation
{
    public class GovernorateCodeDto
    {
        public Guid? Id { get; set; }
        public Guid? CountryCodeId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string GovernorateNameL1 { get; set; } = null!;

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string GovernorateNameL2 { get; set; } = null!;
    }
}
