using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// github token key for terminal use: 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
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
