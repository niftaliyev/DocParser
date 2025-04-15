using System.ComponentModel.DataAnnotations;

namespace DocParser.Api.Dto;

public record FileUploadRequest
{
    [Required]
    public IFormFile File { get; init; } = null!;
}
