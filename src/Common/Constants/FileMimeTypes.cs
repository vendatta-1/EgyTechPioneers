namespace Common.Constants;

public static class FileMimeTypes
{
 
    public static readonly Dictionary<string, string> MimeMappings = new()
    {
        // Source code
        { ".cs", "text/plain" }, { ".cpp", "text/plain" }, { ".h", "text/plain" }, { ".java", "text/plain" },
        { ".py", "text/plain" }, { ".js", "application/javascript" }, { ".ts", "application/typescript" },
        { ".rb", "text/plain" }, { ".go", "text/plain" }, { ".php", "application/x-httpd-php" },
        { ".html", "text/html" }, { ".htm", "text/html" }, { ".css", "text/css" },
        { ".ipynb", "application/x-ipynb+json" },

        // Data / structured
        { ".json", "application/json" }, { ".xml", "application/xml" }, { ".csv", "text/csv" },
        { ".yaml", "application/x-yaml" }, { ".yml", "application/x-yaml" },

        // Archives / compressed
        { ".zip", "application/zip" }, { ".rar", "application/vnd.rar" }, { ".7z", "application/x-7z-compressed" },
        { ".tar", "application/x-tar" }, { ".gz", "application/gzip" }, { ".bz2", "application/x-bzip2" },

        // Office docs
        { ".doc", "application/msword" },
        { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
        { ".xls", "application/vnd.ms-excel" },
        { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
        { ".ppt", "application/vnd.ms-powerpoint" },
        { ".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation" },
        { ".odt", "application/vnd.oasis.opendocument.text" },
        { ".ods", "application/vnd.oasis.opendocument.spreadsheet" },
        { ".odp", "application/vnd.oasis.opendocument.presentation" },

        // PDF / Text
        { ".pdf", "application/pdf" }, { ".txt", "text/plain" }, { ".rtf", "application/rtf" },

        // Images
        { ".png", "image/png" }, { ".jpg", "image/jpeg" }, { ".jpeg", "image/jpeg" },
        { ".gif", "image/gif" }, { ".bmp", "image/bmp" }, { ".svg", "image/svg+xml" },
        { ".webp", "image/webp" }, { ".tiff", "image/tiff" },

        // Audio
        { ".mp3", "audio/mpeg" }, { ".wav", "audio/wav" }, { ".ogg", "audio/ogg" },
        { ".aac", "audio/aac" }, { ".flac", "audio/flac" }, { ".wma", "audio/x-ms-wma" },
        { ".m4a", "audio/mp4" },

        // Video
        { ".mp4", "video/mp4" }, { ".avi", "video/x-msvideo" }, { ".mkv", "video/x-matroska" },
        { ".mov", "video/quicktime" }, { ".wmv", "video/x-ms-wmv" }, { ".flv", "video/x-flv" },
        { ".webm", "video/webm" }
    };

}