using DocParser.Domain.Models;
using DocParser.Domain.Parsers;
using DocumentFormat.OpenXml.Packaging;

namespace DocParser.Infrastructure.Parsers; 

public class WordParser : IDocParser
{
    public bool CanHandle(string extension) => extension == ".docx";

    public async Task<ParseResult> ParseAsync(Stream fileStream)
    {
        using var mems = new MemoryStream();
        await fileStream.CopyToAsync(mems);
        mems.Position = 0;

        using var doc = WordprocessingDocument.Open(mems, false);
        var text = doc.MainDocumentPart?.Document.Body?.InnerText ?? string.Empty;
        return new ParseResult
        {
            FileType = "docx",
            Text = text
        };
    }
}
