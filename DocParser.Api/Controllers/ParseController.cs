using DocParser.Api.Dto;
using DocParser.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocParser.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParseController(IDocParserService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ParseAsync([FromForm] FileUploadRequest request)
    {
        if(request.File == null || request.File.Length == 0)
            return BadRequest("File is required.");

        var extension = Path.GetExtension(request.File.FileName).ToLower();
        var result = await service.ParseAsync(request.File.OpenReadStream(), extension);

        if (result == null)
            return NotFound("File type not supported.");
        
        return Ok(result);
    }
}
