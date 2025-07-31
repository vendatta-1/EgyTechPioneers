 
using Common;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public class StudentGroup : Entity
{ 
    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    public int GroupNo { get; set; }

    public string GroupNameL1 { get; set; } = null!;

    public string? GroupNameL2 { get; set; }

    public Guid? AcademyClaseDetailsId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? DataFinch { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public bool? Saturday { get; set; }

    public bool? OnlineS { get; set; }

    public bool? OfflineS { get; set; }

    public bool? Sunday { get; set; }

    public bool? OnlineSu { get; set; }

    public bool? OfflineSu { get; set; }

    public bool? Monday { get; set; }

    public bool? OnlineM { get; set; }

    public bool? OfflineM { get; set; }

    public bool? Tuesday { get; set; }

    public bool? OnlineT { get; set; }

    public bool? OfflineT { get; set; }

    public bool? Wednesday { get; set; }

    public bool? OnlineW { get; set; }

    public bool? OfflineW { get; set; }

    public bool? Thursday { get; set; }

    public bool? OnlineTh { get; set; }

    public bool? OfflineTh { get; set; }

    public bool? Friday { get; set; }

    public bool? OnlineF { get; set; }

    public bool? OfflineF { get; set; }

    public Guid? TeacherDataId { get; set; }

    public int? NumberStudents { get; set; }

    public Guid? AcademyCourseId { get; set; }

    public string? Description { get; set; }

    public virtual AcademyClaseDetail AcademyClaseDetails { get; set; }

    public virtual BrancheData BranchesData { get; set; }

    public virtual ICollection<StudentData> StudentData { get; set; } = new List<StudentData>();
}