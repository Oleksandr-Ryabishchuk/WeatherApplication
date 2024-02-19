namespace WeatherApplication.Server.DTOs
{
    public class CurrentWeatherViewDto
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public double CloudsAll { get; set; }
    }
}
