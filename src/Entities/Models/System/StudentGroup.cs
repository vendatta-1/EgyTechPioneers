using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;
using Entities.Models.BasicInformation;

namespace Entities.Models.System;

public class StudentGroup : Entity
{
    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GroupNo { get; set; }

    [StringLength(70, MinimumLength = 3)] public string GroupNameL1 { get; set; } = null!;
    [StringLength(70, MinimumLength = 3)] public string? GroupNameL2 { get; set; }

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
    [StringLength(500,MinimumLength = 10)]

    public string? Description { get; set; }

    public virtual AcademyClaseDetail AcademyClaseDetails { get; set; }

    public virtual BranchData BranchesData { get; set; }

    public virtual ICollection<StudentData> StudentData { get; set; } = new HashSet<StudentData>();
}