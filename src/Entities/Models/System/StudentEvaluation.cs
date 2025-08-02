using System.ComponentModel.DataAnnotations;
using Common;

namespace Entities.Models.System;

public partial class StudentEvaluation : Entity
{
    public Guid? StudentDataId { get; set; }

    [DataType("decimal(18,2)")] public decimal? AttendanceRate { get; set; }
    [DataType("decimal(18,2)")] public decimal? AbsenceRate { get; set; }
    [DataType("decimal(18,2)")] public decimal? BrowsingRate { get; set; }
    [DataType("decimal(18,2)")] public decimal? ContentRatio { get; set; }


    public virtual StudentData StudentData { get; set; }
}