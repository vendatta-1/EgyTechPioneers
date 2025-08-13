using Logic.Interfaces.Helpers;
using Microsoft.AspNetCore.Http;

namespace Logic.Implementations.Helpers;

public class FileService : IFileService
{
    private readonly string _rootPath;

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
        await File.WriteAllTextAsync(metadataPath, Path.GetExtension(file.FileName));

        return fileId;
    }

    public (FileStream? Stream, string? RealExtension) Get<T>(string? fileId, string fakeExtension = ".dat")
    {
        if(fileId is null)
            return (null, null);
        
        string filePath = GetFilePath<T>(fileId, fakeExtension);
        string metadataPath = GetMetadataPath<T>(fileId);

        if (!File.Exists(filePath)) return (null, null);

        string? realExtension = File.Exists(metadataPath)
            ? File.ReadAllText(metadataPath).Trim()
            : null;

        return (new FileStream(filePath, FileMode.Open, FileAccess.Read), realExtension);
    }

    public byte[]? Read<T>(string? fileId, string fakeExtension = ".dat")
    {
        if (fileId is null)
            return (null);
        string filePath = GetFilePath<T>(fileId, fakeExtension);
        return File.Exists(filePath) ? File.ReadAllBytes(filePath) : null;
    }

    public bool Exists<T>(string? fileId, string fakeExtension = ".dat")
    {
        if (fileId is null)
            return (false);
        
        string filePath = GetFilePath<T>(fileId, fakeExtension);
        return File.Exists(filePath);
    }

    [Obsolete("is not do anything and don't remove the files it keep it related to soft delete operations in the future will introduce hard delete")]
    public bool Delete<T>(string? fileId, string fakeExtension = ".dat")
    {
        if (fileId is null)
        {
            return false;
        }
        string filePath = GetFilePath<T>(fileId, fakeExtension);
        string metadataPath = GetMetadataPath<T>(fileId);

        if (!File.Exists(filePath)) return false;

        // File.Delete(filePath);
        if (File.Exists(metadataPath))
            return false;
            // File.Delete(metadataPath);

        return true;
    }

    public string? GetAttachmentUrl<T>(string? fileId, string endpointRoute, string fakeExtension = ".dat")
    {
        if (fileId is null)
            return (null);
        
        return Exists<T>(fileId, fakeExtension)
            ? $"{endpointRoute}/{fileId}"
            : null;
    }

    public string? GetPhysicalPath<T>(string? fileId, string fakeExtension = ".dat")
    {
        if (fileId is null)
            return (null);
        return GetFilePath<T>(fileId, fakeExtension);
    }
}
