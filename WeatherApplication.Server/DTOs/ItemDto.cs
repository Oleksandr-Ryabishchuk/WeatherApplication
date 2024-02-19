namespace WeatherApplication.Server.DTOs
{
    public class ItemDto
    {
        public int Dt { get; set; }
        public double Temp { get; set; } = 0;
        public double FeelsLike { get; set; } = 0;
        public double TempMin { get; set; } = 0;
        public double TempMax { get; set; } = 0;
        public int Pressure { get; set; } = 0;
        public int SeaLevel { get; set; } = 0;
        public int GroundLevel { get; set; } = 0;
        public int Humidity { get; set; } = 0;
        public double MinMaxTempDiff { get; set; } = 0;
        public string WeatherMain { get; set; } = string.Empty;
        public string WeatherDescription { get; set; } = string.Empty;
        public string WeatherIcon { get; set; } = string.Empty;
        public int Visibility { get; set; } = 0;
        public double Pop { get; set; } = 0;
        public string? Rain { get; set; }
        public string? Snow { get; set; }
        public string DateText { get; set; } = string.Empty;
        public int CloudsAll { get; set; } = 0;
        public double WindSpeed { get; set; } = 0;
        public int WindDeg { get; set; } = 0;
        public double WindGust { get; set; } = 0;
    }
}
