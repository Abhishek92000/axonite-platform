using Calid.Api.Models;
using Calid.Api.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var calIdOptions = builder.Configuration
    .GetSection(CalIdOptions.SectionName)
    .Get<CalIdOptions>() ?? new CalIdOptions();

builder.Services.Configure<CalIdOptions>(builder.Configuration.GetSection(CalIdOptions.SectionName));

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // Return the same flat { error } shape for model-validation failures as the
        // service layer does, instead of ASP.NET's default ProblemDetails payload.
        options.InvalidModelStateResponseFactory = context =>
        {
            var firstError = context.ModelState.Values
                .SelectMany(value => value.Errors)
                .Select(error => error.ErrorMessage)
                .FirstOrDefault(message => !string.IsNullOrWhiteSpace(message))
                ?? "The request body is invalid.";

            return new BadRequestObjectResult(new { error = firstError });
        };
    });
builder.Services.AddOpenApi();

builder.Services.AddHttpClient<ICalIdService, CalIdService>(client =>
{
    client.BaseAddress = new Uri(calIdOptions.ApiBaseUrl.TrimEnd('/') + "/");
    client.Timeout = TimeSpan.FromSeconds(30);
});

// The React app runs on a different origin; allow the configured origins plus any localhost port.
var allowedOrigins = calIdOptions.AllowedOrigins
    .Where(origin => !string.IsNullOrWhiteSpace(origin))
    .ToArray();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy
        .SetIsOriginAllowed(origin =>
            allowedOrigins.Contains(origin, StringComparer.OrdinalIgnoreCase) ||
            (calIdOptions.AllowLocalhostOrigins && IsLocalhost(origin)))
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());
});

var app = builder.Build();

if (!calIdOptions.HasApiKey)
{
    app.Logger.LogWarning(
        "CalId:ApiKey is missing or still a placeholder. Set it in appsettings.Development.json " +
        "or user secrets before calling the Cal.id API.");
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();
app.MapControllers();

app.Run();

static bool IsLocalhost(string origin) =>
    origin.StartsWith("http://localhost:", StringComparison.OrdinalIgnoreCase) ||
    origin.StartsWith("https://localhost:", StringComparison.OrdinalIgnoreCase) ||
    origin.StartsWith("http://127.0.0.1:", StringComparison.OrdinalIgnoreCase) ||
    origin.StartsWith("https://127.0.0.1:", StringComparison.OrdinalIgnoreCase);
