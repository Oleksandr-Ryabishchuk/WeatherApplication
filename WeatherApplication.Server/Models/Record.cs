using WeatherApplication.Server.Interfaces;

namespace WeatherApplication.Server.Models
{
    public class Record
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
