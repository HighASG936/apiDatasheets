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
    builder.WebHost.UseUrls($"http://*:8080");
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
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownProxies.Clear();
    options.KnownNetworks.Clear();
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

if (!InProduction)
{
    app.UseHttpsRedirection();
}

app.Run();
