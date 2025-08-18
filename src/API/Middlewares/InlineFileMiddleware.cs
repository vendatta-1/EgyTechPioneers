using Logic.Streams;
using Microsoft.Extensions.Primitives;

public class InlineFileMiddleware
{
    private readonly RequestDelegate _next;

    public InlineFileMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
      
        if (context.Request.Method == HttpMethods.Get)
        {
            var originalBodyStream = context.Response.Body;
            var customStream = new HeaderModifyingStream(originalBodyStream);
            context.Response.Body = customStream;

            try
            {
                await _next(context);

                if (context.Response.ContentType != null &&
                    (context.Response.ContentType.StartsWith("image/"))) /*||
                     context.Response.ContentType.StartsWith("text/") ||
                     context.Response.ContentType.StartsWith("application/pdf") ||
                     context.Response.ContentType.StartsWith("video/")))*/
                {
                    string fileName = context.Response.Headers.TryGetValue("Content-Disposition", out var values)
                        ? ParseFileName(values)
                        : "file";
                
                    context.Response.Headers["Content-Disposition"] = $"inline; filename=\"{fileName}\"";
                }
            }
            finally
            {
                context.Response.Body = originalBodyStream;
               
            }
            await customStream.SendPreambleAsync();
        }
        else
        {
        
            await _next(context);
        }
    }
    private string ParseFileName(StringValues values)
    {
        var str = values.FirstOrDefault();
        if (string.IsNullOrEmpty(str)) return "file";
        var fileNamePart = str.Split("filename=").LastOrDefault()?.Trim('"');
        return string.IsNullOrEmpty(fileNamePart) ? "file" : fileNamePart;
    }
}

public static class InlineFileMiddlewareExtensions
{
    public static IApplicationBuilder UseInlineFileMiddleware(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<InlineFileMiddleware>();
        return builder;
    }
}