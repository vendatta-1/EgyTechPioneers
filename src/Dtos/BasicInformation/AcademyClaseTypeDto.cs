using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.BasicInformation
{
    public class AcademyClaseTypeDto
    {
        public Guid? Id { get; set; }
        [Required, MaxLength(100)]
        public string ClassTypeNameId { get; set; } = null!;
    }
}
