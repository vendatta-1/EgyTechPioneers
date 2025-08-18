using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Constants;
using Common.CustomAttributes;

namespace Dtos.System
{
    public class ProgramsContentMasterDto
    {
        public Guid? Id { get; set; }
        public Guid? ProgramsDetailsId { get; set; }
        [StringLength(70, MinimumLength = 2), Required]
        public string SessionNameL1 { get; set; } = null!;

        [StringLength(70, MinimumLength = 2)] 
        public string? SessionNameL2 { get; set; }

        public int? SessionNo { get; set; }
        [AllowedExtensions(FileGroupType.Documents, FileGroupType.Archives)]
        public IFormFile? ScientificMaterial { get; set; }
 

        [StringLength(500, MinimumLength = 3)]
        public string? Description { get; set; }
    }
}