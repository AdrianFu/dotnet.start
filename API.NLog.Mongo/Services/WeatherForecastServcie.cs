namespace API.NLog.Mongo.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly ILogger<WeatherForecastService> _logger;
    public WeatherForecastService(
        ILogger<WeatherForecastService> logger
    )
    {
        _logger = logger;
    }

    async public Task Forecast()
    {
        _logger.LogCritical("Weather forecated");
        await Task.CompletedTask;
    }
}