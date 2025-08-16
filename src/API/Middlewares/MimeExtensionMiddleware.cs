public class MimeExtensionMiddleware
{
    private readonly RequestDelegate _next;

    public MimeExtensionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (!context.Response.HasStarted)
        {
            if (context.Response.ContentType != null)
            {
                var inlineTypes = new[]
                {
                    "image/png", "image/jpeg", "image/gif", "image/webp", "image/svg+xml", "text/plain"
                };

                bool forceDownload = context.Request.Query.TryGetValue("download", out var val) && val == "true";

                if (forceDownload || !inlineTypes.Contains(context.Response.ContentType))
                    context.Response.Headers["Content-Disposition"] = "attachment";
                else
                    context.Response.Headers["Content-Disposition"] = "inline";
            }
        }
    }
}