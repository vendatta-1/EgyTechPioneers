
using Common;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class StudentEvaluation : Entity
{ 

    public Guid? StudentDataId { get; set; }

    public decimal? AttendanceRate { get; set; }

    public decimal? AbsenceRate { get; set; }

    public decimal? BrowsingRate { get; set; }

    public decimal? ContentRatio { get; set; }


    public virtual StudentData StudentData { get; set; }
}