using apiDatasheets.Models;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

bool InProduction = true;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatasheetContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

if (!InProduction)
{
    // Configure Swagger for development environment
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}
else
{
    // Set port for production environment
    var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
    builder.WebHost.UseUrls($"http://*:{port}");
}


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configure forwarded headers for proxies in production
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.All;
});

var app = builder.Build();


// Configure the HTTP request pipeline
//if (!InProduction)
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

// Apply forwarded headers middleware for proxies
app.UseForwardedHeaders();

// Apply CORS policy
app.UseCors("AllowAll");

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
