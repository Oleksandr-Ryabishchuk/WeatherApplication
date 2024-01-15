using AutoMapper;
using WeatherApplication.Server.DTOs.CurrentWeather;
using WeatherApplication.Server.Models;

namespace WeatherApplication.Server.AutoMapper
{
    public class CurrentWeatherProfile: Profile
    {
        public CurrentWeatherProfile()
        {
            CreateMap<CurrentWeather, CurrentWeatherDto>()
                .ReverseMap();
        }
    }
}
