namespace DocParser.Domain.Models;

public class ParseResult
{
    public string Text { get; set; } = string.Empty;
    public string FileType { get; set; } = string.Empty;
    public Dictionary<string, string> Metadata { get; set; } = new();
}
