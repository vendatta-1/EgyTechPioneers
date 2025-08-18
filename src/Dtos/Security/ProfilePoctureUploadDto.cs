using System.ComponentModel.DataAnnotations;
using Common.Constants;
using Common.CustomAttributes;
using Microsoft.AspNetCore.Http;

namespace Dtos.Security;

public class ProfilePictureUploadDto
{
    [Required]
    [AllowedExtensions(FileGroupType.Images)]
    public IFormFile File { get; set; } = null!;
}