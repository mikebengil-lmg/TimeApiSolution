var builder = WebApplication.CreateBuilder(args);

// Load base + environment-specific config
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

var config = builder.Configuration;
var app = builder.Build();

// Read the environment label from configuration
var envLabel = config["EnvironmentLabel"] ?? builder.Environment.EnvironmentName;

app.MapGet("/time", () => new
{
    time = DateTime.UtcNow,
    environment = $"You are running {envLabel} version of this API"
});

app.Run();