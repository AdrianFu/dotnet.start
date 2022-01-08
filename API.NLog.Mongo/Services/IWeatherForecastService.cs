namespace API.NLog.Mongo.Services;

public interface IWeatherForecastService
{
    Task Forecast();
}