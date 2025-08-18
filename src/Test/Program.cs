using System.ComponentModel.DataAnnotations;
using Logic.Implementations.Helpers;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.Extensions.Primitives;
using Test;

public class FakeFormFile : IFormFile
{
    private readonly Stream _stream;
    public string FileName { get; }
    public string ContentType { get; }
 
    public FakeFormFile(string content, string fileName, string contentType = "text/plain")
    {
        _stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
        FileName = fileName;
        ContentType = contentType;
    }
 
    public FakeFormFile(byte[] fileBytes, string fileName, string contentType)
    {
        _stream = new MemoryStream(fileBytes);
        FileName = fileName;
        ContentType = contentType;
    }

    public string ContentDisposition => $"inline; filename={FileName}";
    public IHeaderDictionary Headers => new HeaderDictionary
    {
        { "Content-Type", new StringValues(ContentType) }
    };

    public long Length => _stream.Length;
    public string Name => "FakeFile";

    public void CopyTo(Stream target) => _stream.CopyTo(target);
    public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default) => _stream.CopyToAsync(target, cancellationToken);
    public Stream OpenReadStream() => _stream;
}

class Program
{ 

    // static void Main()
    // {
    //
    //     var student = new Student()
    //     {
    //         FirstName = "Abdullah",
    //         LastName = "Abdullah",
    //         EndDate = DateOnly.FromDayNumber(4),
    //         StartDate = null,
    //         IsActive = true
    //     };
    //     var context = new ValidationContext(student);
    //     var results = new List<ValidationResult>();
    //     
    //  
    //     bool isValid = Validator.TryValidateObject(student, context, results, true);
    //
    //     foreach (var error in results)
    //     {
    //         Console.WriteLine(error.ErrorMessage);
    //     }
    //
    // }
    static void Main()
    {
       
        var csFile = new FakeFormFile("public class Test {}", "Test.cs", "text/plain");
        Console.WriteLine($"[SourceCode] {csFile.FileName} - {csFile.ContentType}");
 
        var jsonFile = new FakeFormFile("{\"name\":\"Abdullah\"}", "data.json", "application/json");
        Console.WriteLine($"[JSON] {jsonFile.FileName} - {jsonFile.ContentType}");

         
        var imgBytes = File.ReadAllBytes("/home/ashry/Documents/photo_7_2025-07-03_17-14-40.jpg");
        var imageFile = new FakeFormFile(imgBytes, "test.jpg", "image/jpeg");
        Console.WriteLine($"[Image] {imageFile.FileName} - {imageFile.ContentType}");

     
        var videoBytes = File.ReadAllBytes("/run/media/ashry/F97C-7579/Building Webhooks in .NET_ Adding PostgreSQL Database Storage (part 2)(720P_60FPS).mp4");
        var videoFile = new FakeFormFile(videoBytes, "video.mp4", "video/mp4");
        Console.WriteLine($"[Video] {videoFile.FileName} - {videoFile.ContentType}");

     
        var audioBytes = File.ReadAllBytes("/home/ashry/test.wav");
        var audioFile = new FakeFormFile(audioBytes, "audio.wav", "audio/wav");
        Console.WriteLine($"[Audio] {audioFile.FileName} - {audioFile.ContentType}");

        var studnet = new Student()
        {
            File = audioFile
        };
        var context = new ValidationContext(studnet);
        var results = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(studnet, context, results, true);
        foreach (var result in results)
        {
            Console.WriteLine(result.ErrorMessage);
        }
  
    }
}
