using System.ComponentModel.DataAnnotations;
using Common;

namespace Entities.Models.Complaints;

public class ComplaintsType : Entity
{
 

    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    [MaxLength(70)]
    public string TypeNameL1 { get; set; } = null!;
    [MaxLength(70)]
    public string? TypeNameL2 { get; set; } = null!;

    public virtual ICollection<ComplaintsStudent> ComplaintsStudents { get; set; } = new List<ComplaintsStudent>();
}