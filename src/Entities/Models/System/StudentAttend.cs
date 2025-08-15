using Common;

namespace Entities.Models.System;

public class StudentAttend : Entity
{
  

    public Guid? StudentDataId { get; set; }

    //public long? DayWeekId { get; set; }

    public DateOnly? DateAttend { get; set; }

    public bool? AttendAccept { get; set; } = false;
    public virtual StudentData StudentData { get; set; }
}