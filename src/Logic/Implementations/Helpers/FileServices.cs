using Logic.Interfaces.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;

namespace Logic.Implementations.Helpers;

public class FileService : IFileService
{
    private readonly string _rootPath;
    
    private static readonly FileExtensionContentTypeProvider _provider = new();
    private static readonly Dictionary<string, string> MimeMappings = new()
    {
        { ".cs", "text/plain" }, { ".cpp", "text/plain" }, { ".h", "text/plain" }, { ".java", "text/plain" },
        { ".py", "text/plain" }, { ".js", "application/javascript" }, { ".ts", "application/typescript" },
        { ".rb", "text/plain" }, { ".go", "text/plain" }, { ".php", "application/x-httpd-php" },
        { ".html", "text/html" }, { ".htm", "text/html" }, { ".css", "text/css" }, { ".json", "application/json" },
        { ".xml", "application/xml" }, { ".ipynb", "application/x-ipynb+json" },
        { ".zip", "application/zip" }, { ".rar", "application/vnd.rar" }, { ".7z", "application/x-7z-compressed" },
        { ".tar", "application/x-tar" }, { ".gz", "application/gzip" }, { ".bz2", "application/x-bzip2" },
        { ".doc", "application/msword" }, { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
        { ".xls", "application/vnd.ms-excel" }, { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
        { ".ppt", "application/vnd.ms-powerpoint" }, { ".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation" },
        { ".pdf", "application/pdf" }, { ".txt", "text/plain" }, { ".csv", "text/csv" },
        { ".png", "image/png" }, { ".jpg", "image/jpeg" }, { ".jpeg", "image/jpeg" },
        { ".gif", "image/gif" }, { ".bmp", "image/bmp" }, { ".svg", "image/svg+xml" }, { ".webp", "image/webp" },
        { ".mp3", "audio/mpeg" }, { ".wav", "audio/wav" }, { ".ogg", "audio/ogg" },
        { ".mp4", "video/mp4" }, { ".avi", "video/x-msvideo" }, { ".mkv", "video/x-matroska" },
    };

    public FileService()
    {
        _rootPath = Path.Combine(Directory.GetCurrentDirectory(), "ApplicationResources");
    }

    private static string GetEntityFolder<T>() => typeof(T).Name;

    private string GetDirectoryPath<T>() => Path.Combine(_rootPath, GetEntityFolder<T>());

    private string GetFilePath<T>(string fileId, string fakeExtension) =>
        Path.Combine(GetDirectoryPath<T>(), $"{fileId}{fakeExtension}");

    private string GetMetadataPath<T>(string fileId) =>
        Path.Combine(GetDirectoryPath<T>(), $"{fileId}.meta");

    public async Task<string> SaveAsync<T>(IFormFile file, string fakeExtension = ".dat")
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("Invalid file.");

        string fileId = Guid.NewGuid().ToString("N");
        string directory = GetDirectoryPath<T>();
        Directory.CreateDirectory(directory);

        string filePath = GetFilePath<T>(fileId, fakeExtension);
        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        string metadataPath = GetMetadataPath<T>(fileId);
        string fileNameWithExtension = file.FileName;
        await File.WriteAllTextAsync(metadataPath, fileNameWithExtension);

        return fileId;
    }

    public (FileStream? Stream, string? FileName) Get<T>(string? fileId, string fakeExtension = ".dat")
    {
        if (fileId is null)
            return (null, null);

        string filePath = GetFilePath<T>(fileId, fakeExtension);
        string metadataPath = GetMetadataPath<T>(fileId);

        if (!File.Exists(filePath)) return (null, null);

        string? fileName = File.Exists(metadataPath) ? File.ReadAllText(metadataPath).Trim() : null;

        return (new FileStream(filePath, FileMode.Open, FileAccess.Read), fileName);
    }

    public byte[]? Read<T>(string? fileId, string fakeExtension = ".dat")
    {
        if (fileId is null)
            return null;
        string filePath = GetFilePath<T>(fileId, fakeExtension);
        return File.Exists(filePath) ? File.ReadAllBytes(filePath) : null;
    }

    public bool Exists<T>(string? fileId, string fakeExtension = ".dat")
    {
        if (fileId is null)
            return false;

        string filePath = GetFilePath<T>(fileId, fakeExtension);
        return File.Exists(filePath);
    }

    public bool Delete<T>(string? fileId, string fakeExtension = ".dat")
    {
        if (fileId is null) return false;

        string filePath = GetFilePath<T>(fileId, fakeExtension);
        string metadataPath = GetMetadataPath<T>(fileId);

        if (!File.Exists(filePath)) return false;
        if (!File.Exists(metadataPath)) return false;

        return true;
    }

    public string? GetAttachmentUrl<T>(string? fileId, string endpointRoute, string fakeExtension = ".dat")
    {
        if (fileId is null) return null;
        return Exists<T>(fileId, fakeExtension) ? $"{endpointRoute}/{fileId}" : null;
    }

    public string? GetPhysicalPath<T>(string? fileId, string fakeExtension = ".dat")
    {
        if (fileId is null) return null;
        return GetFilePath<T>(fileId, fakeExtension);
    }

    public string GetMimeType(string fileName)
    {
        if (!MimeMappings.TryGetValue(fileName, out var contentType))
            contentType = "application/octet-stream";
        return contentType;
    }
}
