using WeatherApplication.Server.Models;

namespace WeatherApplication.Server.DTOs
{
    public class RecordDto
    {       
        public string City { get; set; } = string.Empty;
        public double Lat { get; set; } = 0;
        public double Lon { get; set; } = 0;
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;  
        public DateTime CreatedAt { get; set; }     
        public CurrentWeatherViewDto? CurrentWeather { get; set; }
        public FiveDaysWeatherViewDto? FiveDaysWeather { get; set; }
    }
}
