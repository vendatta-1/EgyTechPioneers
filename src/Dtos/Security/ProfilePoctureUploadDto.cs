using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Dtos.Security;

public class ProfilePictureUploadDto
{
    [Required]
    public IFormFile File { get; set; } = null!;
}