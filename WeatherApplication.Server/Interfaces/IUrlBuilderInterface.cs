using WeatherApplication.Server.DTOs;

namespace WeatherApplication.Server.Interfaces
{
    public interface IUrlBuilderInterface
    {
        string GetGeocodeUrl(OpenWeather openWeather, string city, int? stateCode, int? countryCode);
        string GetWeatherUrl(string template, GeoCodeDto geoCode, OpenWeather openWeather);
    }
}
