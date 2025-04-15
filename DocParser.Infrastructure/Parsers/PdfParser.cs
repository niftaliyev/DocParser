using DocParser.Domain.Models;
using DocParser.Domain.Parsers;
using UglyToad.PdfPig;

namespace DocParser.Infrastructure.Parsers;

public class PdfParser : IDocParser
{
    public bool CanHandle(string extension) => extension == ".pdf"; 

    public async Task<ParseResult> ParseAsync(Stream fileStream)
    {
        using var doc = PdfDocument.Open(fileStream);
        var text = string.Join("\n",doc.GetPages().Select(x => x.Text));
        return new ParseResult
        {
            FileType = "pdf",
            Text = text,
            Metadata = new() { { "pAges", doc.NumberOfPages.ToString() } }
        };
    }
}
