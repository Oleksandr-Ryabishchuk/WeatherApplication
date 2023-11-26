namespace WeatherApplication.Server.DTOs
{
    public class GeoCodeDto
    {
        public string Name { get; set; } = string.Empty;
        public double Lat { get; set; } = 0;
        public double Lon { get; set; } = 0;
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
    }
}