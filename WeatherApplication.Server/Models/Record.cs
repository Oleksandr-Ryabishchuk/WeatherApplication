using WeatherApplication.Server.Interfaces;

namespace WeatherApplication.Server.Models
{
    public class Record: IHasGuidId, IHasDateStamp, IHasSoftDelete
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
