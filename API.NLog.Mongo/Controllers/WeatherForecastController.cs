using Microsoft.AspNetCore.Mvc;
using API.NLog.Mongo.Services;

namespace API.NLog.Mongo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IWeatherForecastService _forecastService;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        IWeatherForecastService forecastService,
        ILogger<WeatherForecastController> logger)
    {
        _forecastService = forecastService;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    async public Task<IEnumerable<WeatherForecast>> Get()
    {
//        using (_logger.BeginScope("Station at {station}", "ConnellsPoint"))
        using (_logger.BeginScope(new[] { new KeyValuePair<string, object>("userid", "sam") }))
        {
            _logger.LogInformation("getting weather forecast at {forcast_time}", DateTime.Now);
            await _forecastService.Forecast();
        }
        _logger.LogWarning("severe weather warning at {forcast_time}", DateTime.Now);
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
