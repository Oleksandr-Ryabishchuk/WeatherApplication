using AutoMapper;
using WeatherApplication.Server.DTOs.CurrentWeather;
using WeatherApplication.Server.Models;

namespace WeatherApplication.Server.AutoMapper
{
    public class CurrentWeatherProfile: Profile
    {
        public CurrentWeatherProfile()
        {
            CreateMap<CurrentWeatherDto, CurrentWeather>()
               .ForMember(x => x.Id, y => y.MapFrom(a => Guid.NewGuid()))
               .ForMember(x => x.CreatedAt, y => y.MapFrom(a => DateTime.Now))
               .ForMember(x => x.DeletedAt, y => y.Ignore())
               .ForMember(x => x.Pressure, y => y.MapFrom(a => a.Main != null ? a.Main.Pressure : 0))
               .ForMember(x => x.Humidity, y => y.MapFrom(a => a.Main != null ? a.Main.Humidity : 0))
               .ForMember(x => x.Temp, y => y.MapFrom(a => a.Main != null ? a.Main.Temp : 0))
               .ForMember(x => x.WindSpeed, y => y.MapFrom(a => a.Wind != null ? a.Wind.Speed : 0))
               .ForMember(x => x.CloudsAll, y => y.MapFrom(a => a.Clouds != null ? a.Clouds.All : 0))
               .ForMember(x => x.TenantId, y => y.MapFrom((src, dest, destMember, context) => context.Items[nameof(CurrentWeather.TenantId)]))
               .ReverseMap();
        }
    }
}
