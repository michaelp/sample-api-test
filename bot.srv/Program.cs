using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1", new OpenApiInfo(){
        Description = "Defi Bot api implementation using Minimal Api in Asp.Net Core",
        Title = "Bot Api",
        Version = "v1",
    });
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        {
           Date= DateTime.Now.AddDays(index),
           TemperatureC=  Random.Shared.Next(-20, 55),
           Summary = summaries[Random.Shared.Next(summaries.Length)]
        })
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithDescription("Some description")
.WithTags("weather")
.Produces<IEnumerable<WeatherForecast>>();

app.Run();
/// <summary>Some Summary of DTO</summary>
class WeatherForecast
{
    /// <summary>Bla bla Summary</summary>
    public string? Summary { get; set; }
    /// <summary>Bla bla Temperature in C</summary>
    public int TemperatureC { get; set; }
    /// <summary>Some Date</summary>
    public DateTime Date { get; set; }
    /// <summary>Bla bla Temperature in F</summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}