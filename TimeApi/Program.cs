
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/time", () => new { time = DateTime.UtcNow });

app.Run();