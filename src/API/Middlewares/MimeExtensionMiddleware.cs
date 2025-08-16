using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class MimeExtensionMiddleware
{
    private readonly RequestDelegate _next;

    private static readonly Dictionary<string, string> MimeMappings = new(StringComparer.OrdinalIgnoreCase)
    {
        { ".cs", "text/plain" }, { ".cpp", "text/plain" }, { ".java", "text/plain" }, { ".py", "text/plain" },
        { ".js", "application/javascript" }, { ".ts", "application/typescript" }, { ".rb", "text/plain" },
        { ".go", "text/plain" }, { ".php", "application/x-httpd-php" }, { ".html", "text/html" },
        { ".css", "text/css" }, { ".json", "application/json" }, { ".xml", "application/xml" },
        { ".ipynb", "application/x-ipynb+json" },

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

    private static readonly Dictionary<string, string> ExtensionMappings = new(StringComparer.OrdinalIgnoreCase);

    static MimeExtensionMiddleware()
    {
        foreach (var kv in MimeMappings)
        {
            if (!ExtensionMappings.ContainsKey(kv.Value))
                ExtensionMappings[kv.Value] = kv.Key;
        }
    }

    public MimeExtensionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var originalBody = context.Response.Body;
        using var memStream = new MemoryStream();
        context.Response.Body = memStream;

        await _next(context);

        context.Response.Body = originalBody;

        if (!context.Response.HasStarted)
        {
            string extension = Path.GetExtension(context.Request.Path.Value ?? string.Empty);

            if (string.IsNullOrWhiteSpace(extension) && !string.IsNullOrEmpty(context.Response.ContentType))
            {
                if (ExtensionMappings.TryGetValue(context.Response.ContentType, out var ext))
                    extension = ext;
            }

            if (!string.IsNullOrWhiteSpace(extension))
            {
                var controller = context.GetRouteValue("controller")?.ToString() ?? "File";
                var action = context.GetRouteValue("action")?.ToString() ?? "Download";

                controller = Regex.Replace(controller, "Controller$", "");
                var match = Regex.Match(controller, @"^[A-Z][a-z]+(?:[A-Z][a-z]+)?");
                var shortController = match.Success ? match.Value : controller;

                var fileName = $"{shortController}{action}{extension}";
                context.Response.Headers["Content-Disposition"] = $"attachment; filename=\"{fileName}\"";
            }
        }

        memStream.Seek(0, SeekOrigin.Begin);
        await memStream.CopyToAsync(originalBody);
    }
}
