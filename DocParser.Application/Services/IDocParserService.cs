using DocParser.Domain.Models;

namespace DocParser.Application.Services;

public interface IDocParserService
{
    Task<ParseResult> ParseAsync(Stream fileStream, string extension);
}
