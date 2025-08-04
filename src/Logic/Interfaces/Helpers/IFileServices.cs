using Microsoft.AspNetCore.Http;

namespace Logic.Interfaces.Helpers
{
    public interface IFileService
    {
        Task<string> SaveAsync<T>(IFormFile file, string fakeExtension = ".dat");
        (FileStream? Stream, string? RealExtension) Get<T>(string? fileId, string fakeExtension = ".dat");
        bool Delete<T>(string? fileId, string fakeExtension = ".dat");
        byte[]? Read<T>(string? fileId, string fakeExtension = ".dat");
        bool Exists<T>(string? fileId, string fakeExtension = ".dat");
        string? GetAttachmentUrl<T>(string? fileId, string endpointRoute, string fakeExtension = ".dat");
        string? GetPhysicalPath<T>(string? fileId, string fakeExtension = ".dat");
    }

}
