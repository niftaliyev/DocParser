using DocParser.Application.Services;
using DocParser.Domain.Models;
using DocParser.Domain.Parsers;
using FluentAssertions;
using Moq;
using Xunit;

namespace DocParser.Tests.DocParser.Tests;

public class DocParserServiceTests
{
    [Fact]
    public async Task Should_Use_Correct_Parser_Docx()
    {
        var mockPrser = new Mock<IDocParser>();
        mockPrser.Setup(p => p.CanHandle(".docx")).Returns(true);
        mockPrser.Setup(x => x.ParseAsync(It.IsAny<Stream>())).ReturnsAsync(new ParseResult { Text = "Test" });

        var service = new DocParserService(new[] { mockPrser.Object });
        var result = await service.ParseAsync(new MemoryStream(), ".docx");

        result.Text.Should().Be("Test");
    }
    [Fact]
    public async Task Should_Use_Correct_Parser_Pdf()
    {
        var mockPrser = new Mock<IDocParser>();
        mockPrser.Setup(p => p.CanHandle(".pdf")).Returns(true);
        mockPrser.Setup(x => x.ParseAsync(It.IsAny<Stream>())).ReturnsAsync(new ParseResult { Text = "Test" });

        var service = new DocParserService(new[] { mockPrser.Object });
        var result = await service.ParseAsync(new MemoryStream(), ".pdf");

        result.Text.Should().Be("Test");
    }
}
