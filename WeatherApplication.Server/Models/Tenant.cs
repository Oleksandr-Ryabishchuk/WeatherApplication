using WeatherApplication.Server.Interfaces;

namespace WeatherApplication.Server.Models
{
    public class Tenant : IHasGuidId, IHasDateStamp, IHasSoftDelete
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Name { get; set; } = string.Empty;
        // One Tenant has many Users
        public ICollection<User>? Users { get; set; }
        public ICollection<Record>? Records { get; set; }
        public ICollection<CurrentWeather>? CurrentWeatherCalls { get; set; }
        public ICollection<FiveDaysWeather>? FiveDaysWeatherCalls { get; set; }
    }
}
