using System.ComponentModel.DataAnnotations;
using Common.CustomAttributes;

namespace Dtos.System
{
    public class StudentGroupDto
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid AcademyDataId { get; set; }

        [Required]
        public Guid BranchDataId { get; set; }

        [StringLength(maximumLength: 70), Required]
        public string GroupNameL1 { get; set; } = null!;

        [StringLength(maximumLength: 70)]
        public string? GroupNameL2 { get; set; }

        public Guid? AcademyClaseDetailsId { get; set; }

        public DateOnly? StartDate { get; set; }
        [CompareWith(nameof(StartDate), ComparisonType.GreaterThan)]
        public DateOnly? DataFinch { get; set; }

        public DateTime? StartTime { get; set; }
        [CompareWith(nameof(StartTime), ComparisonType.GreaterThan)]
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

        [StringLength(500, MinimumLength = 10)]
        public string? Description { get; set; }
    }

}
