using Microsoft.AspNetCore.Http;

namespace Logic.Interfaces.Helpers
{
    public interface IFileService
    {
        Task<string> SaveAsync<T>(IFormFile file, Guid entityId, string fakeExtension = ".dat");
        (FileStream? Stream, string? RealExtension) Get<T>(Guid entityId, string fakeExtension = ".dat");
        bool Delete<T>(Guid entityId, string fakeExtension = ".dat");

        byte[]? Read<T>(Guid entityId, string fakeExtension = ".dat");
        bool Exists<T>(Guid entityId, string fakeExtension = ".dat");
        string? GetAttachmentUrl<T>(Guid entityId, string endpointRoute, string fakeExtension = ".dat");
        string GetPhysicalPath<T>(Guid entityId, string fakeExtension = ".dat");
    }

}
