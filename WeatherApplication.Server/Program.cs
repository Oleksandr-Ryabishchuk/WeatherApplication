using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WeatherApplication.Server.Data;
using WeatherApplication.Server.DTOs;
using WeatherApplication.Server.Interfaces;
using WeatherApplication.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient("OpenWeatherClient", client =>
{
    // Configure your HttpClient options here
    client.BaseAddress = new Uri("https://openweathermap.org/");
    // Additional configuration if needed...
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    options.UseMySql(connectionString, serverVersion);    
});

builder.Services.AddTransient<IUrlBuilderInterface, UrlBuilderService>();
builder.Services.AddTransient<ITenantFinderInterface, TenantFinderService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName); // Use the type's full name as the schema ID
    // Other Swagger configuration...
});

builder.Services.Configure<OpenWeather>(builder.Configuration.GetSection("OpenWeather"));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
