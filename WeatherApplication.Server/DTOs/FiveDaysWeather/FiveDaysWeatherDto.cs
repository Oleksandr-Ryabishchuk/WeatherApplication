using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherApplication.Server.DTOs.FiveDaysWeather
{
    public class FiveDaysWeatherDto
    {
        public string? Cod { get; set; }
        public int Message { get; set; } = 0;
        public int Cnt { get; set; } = 0;
        public List<List>? List { get; set; }
        public City? City { get; set; }
    }
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Coord? Coord { get; set; }
        public string Country { get; set; } = string.Empty;
        public int Population { get; set; } = 0;
        public int Timezone { get; set; } = 0;
        public int Sunrise { get; set; } = 0;
        public int Sunset { get; set; } = 0;
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Coord
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public class List
    {
        public int Dt { get; set; }        
        public Main? Main { get; set; }
        public List<Weather>? Weather { get; set; }
        public Clouds? Clouds { get; set; }
        public Wind? Wind { get; set; }
        public int Visibility { get; set; } = 0;
        public double Pop { get; set; } = 0;
        public Rain? Rain { get; set; }
        public Snow? Snow { get; set; }
        public Sys? Sys { get; set; }
        [JsonProperty("dt_txt")]
        public string DateText { get; set; } = string.Empty;
    }

    public class Main
    {        
        public double Temp { get; set; } = 0;
        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; } = 0;
        [JsonProperty("temp_min")]
        public double TempMin { get; set; } = 0;
        [JsonProperty("temp_max")]
        public double TempMax { get; set; } = 0;
        public int Pressure { get; set; } = 0;
        [JsonProperty("sea_level")]
        public int SeaLevel { get; set; } = 0;
        [JsonProperty("grnd_level")]
        public int GroundLevel { get; set; } = 0;
        public int Humidity { get; set; } = 0;
        [JsonProperty("temp_kf")]
        public double MinMaxTempDiff { get; set; } = 0;
    }

    public class Rain
    {
        [JsonProperty("3h")]
        public double ThreeHours { get; set; } = 0;
    }

    public class Snow
    {
        [JsonProperty("3h")]
        public double ThreeHours { get; set; } = 0;
    }

    public class Sys
    {
        public string Pod { get; set; } = string.Empty;
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }

    public class Wind
    {
        public double Speed { get; set; } = 0;
        public int Deg { get; set; } = 0;
        public double Gust { get; set; } = 0;
    }
}
