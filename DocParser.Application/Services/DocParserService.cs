using DocParser.Domain.Models;
using DocParser.Domain.Parsers;

namespace DocParser.Application.Services;

public class DocParserService(IEnumerable<IDocParser> parsers) : IDocParserService
{
    public async Task<ParseResult> ParseAsync(Stream fileStream, string extension)
    {
        var parser = parsers.FirstOrDefault(p => p.CanHandle(extension));
        if (parser == null)
            throw new NotSupportedException($"No parser found for extension: {extension}");
        return await parser.ParseAsync(fileStream);
    }
}
