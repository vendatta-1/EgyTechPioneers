 
using System.ComponentModel.DataAnnotations;

namespace Dtos.BasicInformation
{
    public class CityCodeDto
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid GovernorateCodeId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string CityNameL1 { get; set; } = null!;

        [StringLength(100)]
        [Required]
        public string CityNameL2 { get; set; } = null!;
    }
}
