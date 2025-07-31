using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
 
        public class EduContactResultDto
        {
            public Guid? CompanyDataId { get; set; }

            public Guid? StudentDataId { get; set; }

            public Guid? ReasonsRejectionId { get; set; }

            public DateTime? DateResult { get; set; }

            public string? Description { get; set; }

            public IFormFile? Attachment { get; set; }
        }


}
