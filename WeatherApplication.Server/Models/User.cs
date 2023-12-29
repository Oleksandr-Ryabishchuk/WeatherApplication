using WeatherApplication.Server.Interfaces;

namespace WeatherApplication.Server.Models
{
    public class User : IHasGuidId, IHasDateStamp, IHasSoftDelete
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        // Every User has one Tenant
        public Guid TenantId { get; set; }
        public Tenant? Tenant { get; set; }
        //
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
