using AutoMapper;
using WeatherApplication.Server.DTOs.FiveDaysWeather;
using WeatherApplication.Server.Models;

namespace WeatherApplication.Server.AutoMapper
{
    public class FiveDaysWeatherProfile: Profile
    {
        public FiveDaysWeatherProfile()
        {
            CreateMap<FiveDaysWeather, FiveDaysWeatherDto>()
                .ReverseMap();
        }
    }
}
