using System.ComponentModel.DataAnnotations;
using Common.Constants;
using Microsoft.AspNetCore.Http;

namespace Common.CustomAttributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class AllowedExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _extensions;
    private readonly string[] _mimeTypes;

    public AllowedExtensionsAttribute(params string[] groupNames)
    {
        var (exts, mimes) = FileGroups.Combine(groupNames);
        _extensions = exts;
        _mimeTypes = mimes;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not IFormFile file) return ValidationResult.Success;

        var extension = Path.GetExtension(file.FileName);
        if (!_extensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
        {
            return new ValidationResult($"File extension {extension} is not allowed.");
        }

        if (!_mimeTypes.Contains(file.ContentType, StringComparer.OrdinalIgnoreCase))
        {
            return new ValidationResult($"MIME type {file.ContentType} is not allowed.");
        }

        return ValidationResult.Success;
    }
}
