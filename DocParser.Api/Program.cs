using DocParser.Application.Services;
using DocParser.Domain.Parsers;
using DocParser.Infrastructure.Parsers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IDocParserService, DocParserService>();
builder.Services.AddScoped<IDocParser, WordParser>();
builder.Services.AddScoped<IDocParser, PdfParser>();

builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.RoutePrefix = "swagger";
    });

}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
