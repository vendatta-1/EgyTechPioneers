using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class StudentEvaluationDto
    {
        public Guid? Id { get; set; }
        public Guid? StudentDataId { get; set; }

        [Range(0, 100)] public decimal? AttendanceRate { get; set; }
        [Range(0, 100)] public decimal? AbsenceRate { get; set; }
        [Range(0, 100)] public decimal? BrowsingRate { get; set; }
        [Range(0, 100)] public decimal? ContentRatio { get; set; }
    }
}