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

    private string GetFilePath<T>(Guid entityId, string fakeExtension) =>
        Path.Combine(GetDirectoryPath<T>(), $"{entityId}{fakeExtension}");

    private string GetMetadataPath<T>(Guid entityId) =>
        Path.Combine(GetDirectoryPath<T>(), $"{entityId}.meta");

    public async Task<string> SaveAsync<T>(IFormFile file, Guid entityId, string fakeExtension = ".dat")
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("Invalid file.");

        string directory = GetDirectoryPath<T>();
        Directory.CreateDirectory(directory);

        string filePath = GetFilePath<T>(entityId, fakeExtension);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        string metadataPath = GetMetadataPath<T>(entityId);
        await File.WriteAllTextAsync(metadataPath, Path.GetExtension(file.FileName));

        return filePath;
    }

    public (FileStream? Stream, string? RealExtension) Get<T>(Guid entityId, string fakeExtension = ".dat")
    {
        string filePath = GetFilePath<T>(entityId, fakeExtension);
        string metadataPath = GetMetadataPath<T>(entityId);

        if (!File.Exists(filePath)) return (null, null);

        string? realExtension = File.Exists(metadataPath)
            ? File.ReadAllText(metadataPath).Trim()
            : null;

        return (new FileStream(filePath, FileMode.Open, FileAccess.Read), realExtension);
    }

    public byte[]? Read<T>(Guid entityId, string fakeExtension = ".dat")
    {
        string filePath = GetFilePath<T>(entityId, fakeExtension);
        return File.Exists(filePath) ? File.ReadAllBytes(filePath) : null;
    }

    public bool Exists<T>(Guid entityId, string fakeExtension = ".dat")
    {
        string filePath = GetFilePath<T>(entityId, fakeExtension);
        return File.Exists(filePath);
    }

    public bool Delete<T>(Guid entityId, string fakeExtension = ".dat")
    {
        string filePath = GetFilePath<T>(entityId, fakeExtension);
        string metadataPath = GetMetadataPath<T>(entityId);

        if (!File.Exists(filePath)) return false;

        File.Delete(filePath);
        if (File.Exists(metadataPath)) File.Delete(metadataPath);

        return true;
    }

    public string? GetAttachmentUrl<T>(Guid entityId, string endpointRoute, string fakeExtension = ".dat")
    {
        return Exists<T>(entityId, fakeExtension)
            ? $"{endpointRoute}/{entityId}"
            : null;
    }

    public string GetPhysicalPath<T>(Guid entityId, string fakeExtension = ".dat")
    {
        return GetFilePath<T>(entityId, fakeExtension);
    }
}
