using AutoMapper;
using WeatherApplication.Server.DTOs;
using WeatherApplication.Server.DTOs.FiveDaysWeather;
using WeatherApplication.Server.Models;

namespace WeatherApplication.Server.AutoMapper
{
    public class FiveDaysWeatherProfile: Profile
    {
        public FiveDaysWeatherProfile()
        {
            CreateMap<FiveDaysWeather, FiveDaysWeatherDto>()
                .ReverseMap()
                .ForMember(x => x.Id, y => y.MapFrom(a => Guid.NewGuid()))
                .ForMember(x => x.CreatedAt, y => y.MapFrom(a => DateTime.Now))
                .ForMember(x => x.DeletedAt, y => y.Ignore())
                .ForMember(x => x.TenantId, y => y.MapFrom((src, dest, destMember, context) => context.Items[nameof(FiveDaysWeather.TenantId)]))
                .ForMember(x => x.Items, y => y.MapFrom((src, dest, destMember, context) => context.Items[nameof(FiveDaysWeather.Items)]))
                .ForMember(x => x.CityName, y => y.MapFrom(a => a.City != null ? a.City.Name : string.Empty))
                .ForMember(x => x.Lat, y => y.MapFrom(a => a.City != null && a.City.Coord != null ? a.City.Coord.Lat : 0))
                .ForMember(x => x.Lon, y => y.MapFrom(a => a.City != null && a.City.Coord != null ? a.City.Coord.Lon : 0))
                .ForMember(x => x.Country, y => y.MapFrom(a => a.City != null ? a.City.Country : string.Empty))
                .ForMember(x => x.Population, y => y.MapFrom(a => a.City != null ? a.City.Population : 0))
                .ForMember(x => x.Timezone, y => y.MapFrom(a => a.City != null ? a.City.Timezone : 0))
                .ForMember(x => x.Sunrise, y => y.MapFrom(a => a.City != null ? a.City.Sunrise : 0))
                .ForMember(x => x.Sunset, y => y.MapFrom(a => a.City != null ? a.City.Sunset : 0));

            CreateMap<FiveDaysWeather, FiveDaysWeatherViewDto>();
                
        }
    }
}
