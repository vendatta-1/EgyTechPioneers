using Common.Constants;
using Common.CustomAttributes;
using Microsoft.AspNetCore.Http;

namespace Test;

public class Student
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? ProfilePicture { get; set; }
    public DateOnly? StartDate { get; set; }
    [CompareWith(nameof(StartDate), ComparisonType.GreaterThan)]
    public DateOnly? EndDate { get; set; }
    public bool IsActive { get; set; } = true;
    [AllowedExtensions(FileGroupType.Audio)]
    public FakeFormFile File { get; set; } 
}