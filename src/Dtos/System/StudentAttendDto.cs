using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.System
{
    public class StudentAttendDto
    {
        public Guid? Id { get; set; }
        public Guid? StudentDataId { get; set; }

        public DateOnly? DateAttend { get; set; }

        public bool? AttendAccept { get; set; }
    }
}
