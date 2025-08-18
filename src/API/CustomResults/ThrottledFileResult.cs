using System.Buffers;
using System.Net.Http.Headers;
using Logic.Streams;
using Microsoft.AspNetCore.Mvc;

namespace API.CustomResults;

/// <summary>
/// used in testing or in custom solutions where delay or control chunks size sent to the client 
/// </summary>
public class ThrottledFileResult : IActionResult
{
    private readonly Stream _fileStream;
    private readonly string _contentType;
    private readonly string _fileName; 

    public ThrottledFileResult(Stream fileStream, string contentType, string fileName, int minKb, int maxKb)
    {
        _fileStream = fileStream;
        _contentType = contentType;
        _fileName = fileName; 
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var response = context.HttpContext.Response;

        
        response.ContentType = _contentType;
        response.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
        {
            FileName = _fileName
        }.ToString();

        
        await using var throttledResponseStream = new ThrottledStream(
            response.Body
        );
 
        const int bufferSize = 64 * 1024; 
        byte[] buffer = ArrayPool<byte>.Shared.Rent(bufferSize);
        int bytesRead;

        try
        {
            while ((bytesRead = await _fileStream.ReadAsync(buffer, 0, buffer.Length, context.HttpContext.RequestAborted)) > 0)
            {
                await throttledResponseStream.WriteAsync(buffer, 0, bytesRead, context.HttpContext.RequestAborted);
            }
        }
        finally
        {
            
            ArrayPool<byte>.Shared.Return(buffer);
            await _fileStream.DisposeAsync();
        }
    }
}