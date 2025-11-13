using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddOpenApi();

// <snippet_UseSwagger>
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}
// </snippet_UseSwagger>

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();