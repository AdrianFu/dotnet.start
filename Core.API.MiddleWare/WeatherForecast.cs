using System;

namespace Core.API.MiddleWare
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public DateTime ReceiveTime {get;set;}
        public string Author {get;set;}
    }
}
