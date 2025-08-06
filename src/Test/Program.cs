using Logic.Implementations.Helpers;
using Microsoft.AspNetCore.Http;
using System.Text;
 
class FakeFormFile : IFormFile
{
    private readonly MemoryStream _stream;
    public string FileName { get; }

    public FakeFormFile(string content, string fileName)
    {
        _stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
        FileName = fileName;
    }

    public string ContentType => "text/plain";
    public string ContentDisposition => $"inline; filename={FileName}";
    public IHeaderDictionary Headers => new HeaderDictionary();
    public long Length => _stream.Length;
    public string Name => "FakeFile";
    public void CopyTo(Stream target) => _stream.CopyTo(target);
    public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default) => _stream.CopyToAsync(target, cancellationToken);
    public Stream OpenReadStream() => _stream;
}

class Program
{
    class DummyEntity { }

    static void Main()
    {  
        
 
 
    }
}
