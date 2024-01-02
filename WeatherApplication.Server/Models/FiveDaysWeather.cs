using WeatherApplication.Server.Interfaces;

namespace WeatherApplication.Server.Models
{
    public class FiveDaysWeather : IHasGuidId, IHasDateStamp, IHasSoftDelete
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid? TenantId { get; set; }
        public Tenant? Tenant { get; set; }
    }
}
