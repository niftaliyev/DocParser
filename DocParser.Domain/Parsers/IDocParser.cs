using DocParser.Domain.Models;

namespace DocParser.Domain.Parsers;

public interface IDocParser
{
    Task<ParseResult> ParseAsync(Stream fileStream);
    bool CanHandle(string extension);
}
