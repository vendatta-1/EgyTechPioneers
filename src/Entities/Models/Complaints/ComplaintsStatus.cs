using System.ComponentModel.DataAnnotations;
using Common;

namespace Entities.Models.Complaints;

public class ComplaintsStatus : Entity
{
 
    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    [MaxLength(100)]
    public string StatusesNameL1 { get; set; } = null!;

    [MaxLength(100)]
    public string StatusesNameL2 { get; set; } = null!;
 
    public virtual ICollection<ComplaintsStudent> ComplaintsStudents { get; set; } = new List<ComplaintsStudent>();
}