using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.BasicInformation
{
    public class CountryCodeDto
    {
        public Guid? Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string CountryNameL1 { get; set; } = null!;

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string CountryNameL2 { get; set; } = null!;
    }
}
