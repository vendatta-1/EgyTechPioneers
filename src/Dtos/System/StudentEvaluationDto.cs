using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class StudentEvaluationDto
    {
        public Guid? StudentDataId { get; set; }

        public decimal? AttendanceRate { get; set; }

        public decimal? AbsenceRate { get; set; }

        public decimal? BrowsingRate { get; set; }

        public decimal? ContentRatio { get; set; }
    }

}
