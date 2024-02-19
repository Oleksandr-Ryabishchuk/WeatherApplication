using WeatherApplication.Server.Models;

namespace WeatherApplication.Server.DTOs
{
    public class FiveDaysWeatherViewDto
    {
        public ICollection<ItemDto>? Items { get; set; }
        public string CityName { get; set; } = string.Empty;
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Country { get; set; } = string.Empty;
        public int Population { get; set; } = 0;
        public int Timezone { get; set; } = 0;
        public int Sunrise { get; set; } = 0;
        public int Sunset { get; set; } = 0;
    }
}
