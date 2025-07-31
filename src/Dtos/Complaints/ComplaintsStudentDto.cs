using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Complaints
{
    public class ComplaintsStudentDto
    {
        public Guid? AcademyDataId { get; set; }

        public Guid? BranchesDataId { get; set; }

        public int ComplaintsNo { get; set; }

        public Guid? ComplaintsTypeId { get; set; }

        public Guid? ComplaintsStatusesId { get; set; }

        public Guid? StudentsDataId { get; set; }

        public DateOnly? Date { get; set; }

        public string Description { get; set; }

        public IFormFile? Files { get; set; }
    }

}
