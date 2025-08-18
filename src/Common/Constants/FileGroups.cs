
namespace Common.Constants;

public static class FileGroups
{
    public static readonly Dictionary<string, (string[] Extensions, string[] MimeTypes)> Groups =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["SourceCode"] = (
                [".cs", ".cpp", ".h", ".java", ".py", ".js", ".ts", ".rb", ".go", ".php", ".html", ".htm", ".css", ".ipynb"
                ],
                GetMimeTypes([".cs", ".cpp", ".h", ".java", ".py", ".js", ".ts", ".rb", ".go", ".php", ".html", ".htm", ".css", ".ipynb"
                ])
            ),
            ["Data"] = (
                [".json", ".xml", ".csv", ".yaml", ".yml"],
                GetMimeTypes([".json", ".xml", ".csv", ".yaml", ".yml"])
            ),
            ["Archives"] = (
                [".zip", ".rar", ".7z", ".tar", ".gz", ".bz2"],
                GetMimeTypes([".zip", ".rar", ".7z", ".tar", ".gz", ".bz2"])
            ),
            ["Documents"] = (
                [".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".odt", ".ods", ".odp", ".pdf", ".txt", ".rtf"],
                GetMimeTypes([".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".odt", ".ods", ".odp", ".pdf", ".txt", ".rtf"
                ])
            ),
            ["Images"] = (
                [".png", ".jpg", ".jpeg", ".gif", ".bmp", ".svg", ".webp", ".tiff"],
                GetMimeTypes([".png", ".jpg", ".jpeg", ".gif", ".bmp", ".svg", ".webp", ".tiff"])
            ),
            ["Audio"] = (
                [".mp3", ".wav", ".ogg", ".aac", ".flac", ".wma", ".m4a"],
                GetMimeTypes([".mp3", ".wav", ".ogg", ".aac", ".flac", ".wma", ".m4a"])
            ),
            ["Video"] = (
                [".mp4", ".avi", ".mkv", ".mov", ".wmv", ".flv", ".webm"],
                GetMimeTypes([".mp4", ".avi", ".mkv", ".mov", ".wmv", ".flv", ".webm"])
            )
        };

    private static string[] GetMimeTypes(string[] extensions)
    {
        return extensions
            .Where(FileMimeTypes.MimeMappings.ContainsKey)
            .Select(ext => FileMimeTypes.MimeMappings[ext])
            .Distinct()
            .ToArray();
    }

    public static (string[] Extensions, string[] MimeTypes) Combine(params string[] groupNames)
    {
        var extensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var mimeTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var name in groupNames)
        {
            if (Groups.TryGetValue(name, out var group))
            {
                extensions.UnionWith(group.Extensions);
                mimeTypes.UnionWith(group.MimeTypes);
            }
        }

        return (extensions.ToArray(), mimeTypes.ToArray());
    }
}
