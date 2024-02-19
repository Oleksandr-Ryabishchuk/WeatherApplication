using AutoMapper;
using WeatherApplication.Server.DTOs;
using WeatherApplication.Server.DTOs.FiveDaysWeather;
using WeatherApplication.Server.Models;

namespace WeatherApplication.Server.AutoMapper
{
    public class ItemProfile: Profile
    {
        public ItemProfile()
        {
            CreateMap<List, Item>()
                .ForMember(x => x.Id, y => y.MapFrom(a => Guid.NewGuid()))
                .ForMember(x => x.FiveDaysWeatherId, y => y.MapFrom((src, dest, destMember, context) => context.Items[nameof(Item.FiveDaysWeatherId)]))
                .ForMember(x => x.FiveDaysWeather, y => y.MapFrom((src, dest, destMember, context) => context.Items[nameof(Item.FiveDaysWeather)]))
                .ForMember(x => x.Dt, y => y.MapFrom(a => a.Dt))
                .ForMember(x => x.Temp, y => y.MapFrom(a => a.Main != null ? a.Main.Temp : 0))
                .ForMember(x => x.FeelsLike, y => y.MapFrom(a => a.Main != null ? a.Main.FeelsLike : 0))
                .ForMember(x => x.TempMin, y => y.MapFrom(a => a.Main != null ? a.Main.TempMin : 0))
                .ForMember(x => x.TempMax, y => y.MapFrom(a => a.Main != null ? a.Main.TempMax : 0))
                .ForMember(x => x.Pressure, y => y.MapFrom(a => a.Main != null ? a.Main.Pressure : 0))
                .ForMember(x => x.SeaLevel, y => y.MapFrom(a => a.Main != null ? a.Main.SeaLevel : 0))
                .ForMember(x => x.GroundLevel, y => y.MapFrom(a => a.Main != null ? a.Main.GroundLevel : 0))
                .ForMember(x => x.Humidity, y => y.MapFrom(a => a.Main != null ? a.Main.Humidity : 0))
                .ForMember(x => x.MinMaxTempDiff, y => y.MapFrom(a => a.Main != null ? a.Main.MinMaxTempDiff : 0))
                .ForMember(x => x.WeatherMain, y => y.MapFrom(a => a.Weather != null && a.Weather.Count > 0 ? a.Weather.First().Main : string.Empty))
                .ForMember(x => x.WeatherDescription, y => y.MapFrom(a => a.Weather != null && a.Weather.Count > 0 ? a.Weather.First().Description : string.Empty))                
                .ForMember(x => x.WeatherIcon, y => y.MapFrom(a => a.Weather != null && a.Weather.Count > 0 ? a.Weather.First().Icon : string.Empty))
                .ForMember(x => x.Visibility, y => y.MapFrom(a => a.Visibility))
                .ForMember(x => x.Pop, y => y.MapFrom(a => a.Pop))
                .ForMember(x => x.Rain, y => y.MapFrom(a => a.Rain != null ? a.Rain.ThreeHours : 0))
                .ForMember(x => x.Snow, y => y.MapFrom(a => a.Snow != null ? a.Snow.ThreeHours : 0))
                .ForMember(x => x.DateText, y => y.MapFrom(a => a.DateText))
                .ForMember(x => x.CloudsAll, y => y.MapFrom(a => a.Clouds != null ? a.Clouds.All : 0))
                .ForMember(x => x.WindSpeed, y => y.MapFrom(a => a.Wind != null ? a.Wind.Speed : 0))
                .ForMember(x => x.WindGust, y => y.MapFrom(a => a.Wind != null ? a.Wind.Gust : 0))
                .ForMember(x => x.WindDeg, y => y.MapFrom(a => a.Wind != null ? a.Wind.Deg : 0));

            CreateMap<Item, ItemDto>();
        }
    }
}
