using WeatherApplication.Server.Models;
using WeatherApplication.Server.Services;
using WeatherApplication.Server.DTOs;

namespace WeatherApplication.Interfaces
{
    public class Record
    {       
        public string City { get; set; } = string.Empty;
        public double Lat { get; set; } = 0;
        public double Lon { get; set; } = 0;
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;        
        public CurrentWeatherViewDto? CurrentWeather { get; set; }
        public FiveDaysWeatherViewDto? FiveDaysWeather { get; set; }
    }
}
