using AutoMapper;
using WeatherApplication.Server.DTOs;
using WeatherApplication.Server.Models;

namespace WeatherApplication.Server.AutoMapper
{
    public class RecordProfile: Profile
    {
        public RecordProfile()
        {
            CreateMap<GeoCodeDto, Record>()
                .ForMember(x => x.Id, y => y.MapFrom(a => Guid.NewGuid()))
                .ForMember(x => x.CreatedAt, y => y.MapFrom(a => DateTime.Now))
                .ForMember(x => x.DeletedAt, y => y.Ignore())
                .ForMember(x => x.TenantId, y => y.MapFrom((src, dest, destMember, context) => context.Items[nameof(Record.TenantId)]))
                .ForMember(x => x.CurrentWeatherId, y => y.MapFrom((src, dest, destMember, context) => context.Items[nameof(Record.CurrentWeatherId)]))
                .ForMember(x => x.FiveDaysWeatherId, y => y.MapFrom((src, dest, destMember, context) => context.Items[nameof(Record.FiveDaysWeatherId)]))
                .ForMember(x => x.City, y => y.MapFrom(a => a.Name))
                .ForMember(x => x.State, y => y.MapFrom(a => a.State))
                .ForMember(x => x.Country, y => y.MapFrom(a => a.Country))
                .ForMember(x => x.Lat, y => y.MapFrom(a => a.Lat))
                .ForMember(x => x.Lon, y => y.MapFrom(a => a.Lon));
        }
    }
}
