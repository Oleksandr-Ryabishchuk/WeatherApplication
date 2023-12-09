using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json; // You need to install Newtonsoft.Json nugget package 
using System.ComponentModel.DataAnnotations;
using System.Text;
using WeatherApplication.Server.DTOs;
using WeatherApplication.Server.DTOs.CurrentWeather;
using WeatherApplication.Server.DTOs.FiveDaysWeather;

namespace WeatherApplication.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly OpenWeather _openWeather;
        private readonly HttpClient _httpClient;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IOptions<OpenWeather> openWeather,
            IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("OpenWeatherClient"); // Use DI to get HTTPClient correctly
            _openWeather = openWeather.Value;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("CurrentWeather")]
        public async Task<ActionResult<CurrentWeatherDto>> GetCurrentWeather([FromQuery][Required] string cityName, // Add one more decorator Task<>
                                                                                                                    // To handle many asynchronous methods
                                                   [FromQuery] int? stateCode,
                                                   [FromQuery] int? countryCode)
        {
            try
            {
                // Check if we got required data at all
                if (_openWeather == null || string.IsNullOrWhiteSpace(cityName))
                {
                    return BadRequest("Some configuration or request is empty"); // Return bad request with message that points to problem
                }

                // Use stringbuilder to build url for geocode
                StringBuilder geocode = new StringBuilder();
                string geocodeUrl = geocode.Append(_openWeather.Site + _openWeather.GeoResponseType + _openWeather.GeoVersion)
                          .Append(_openWeather.GeolocationTemplate.Replace("cityname", cityName)
                          .Replace(",statecode", stateCode.HasValue ? stateCode.Value.ToString() : "")
                          .Replace(",countrycode", countryCode.HasValue ? countryCode.Value.ToString() : "")
                          .Replace("APIKey", _openWeather.Key)).ToString();

                var geoResponse = await _httpClient.GetAsync(geocodeUrl); // Make asynchronous call to Open Weather site

                if (!geoResponse.IsSuccessStatusCode || geoResponse == null || geoResponse.Content == null)
                {
                    return BadRequest("Call to Open Weather for geocode failed");
                }

                string geo = await geoResponse.Content.ReadAsStringAsync(); // Transform response to string
                var geoCode = JsonConvert.DeserializeObject<List<GeoCodeDto>>(geo);

                if (geoCode == null || geoCode == null || geoCode.Count == 0)
                {
                    return BadRequest("Deserialization of geocode failed");
                }

                var firstCity = geoCode.First();

                // if previous actions are successful - create url for current weather
                StringBuilder currentWeatherUrl = new StringBuilder();
                string currentUrl = currentWeatherUrl.Append(_openWeather.Site + _openWeather.WeatherResponseType + _openWeather.WeatherVersion)
                                 .Append(_openWeather.CurrentWeatherTemplate.Replace("=lat", "=" + firstCity.Lat)
                                 .Replace("=lon", "=" + firstCity.Lon).Replace("APIKey", _openWeather.Key)).ToString();

                var currentWeatherResponse = await _httpClient.GetAsync(currentUrl); // Make asynchronous call to Open Weather site
                if (!currentWeatherResponse.IsSuccessStatusCode || currentWeatherResponse == null || currentWeatherResponse.Content == null)
                {
                    return BadRequest("Call to Open Weather for current weather failed");
                }

                string current = await currentWeatherResponse.Content.ReadAsStringAsync(); // Transform response to string
                var currentWeather = JsonConvert.DeserializeObject<CurrentWeatherDto>(current);
                if (currentWeather == null)
                {
                    return BadRequest("Deserialization of current weather failed");
                }

                return Ok(currentWeather);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FiveDaysWeather")]
        public async Task<ActionResult<FiveDaysWeatherDto>> GetFiveDaysWeather([FromQuery][Required] string cityName, // Add one more decorator Task<>
                                                                                                                    // To handle many asynchronous methods
                                                   [FromQuery] int? stateCode,
                                                   [FromQuery] int? countryCode)
        {
            try
            {
                // Check if we got required data at all
                if (_openWeather == null || string.IsNullOrWhiteSpace(cityName))
                {
                    return BadRequest("Some configuration or request is empty"); // Return bad request with message that points to problem
                }

                // Use stringbuilder to build url for geocode
                StringBuilder geocode = new StringBuilder();
                string geocodeUrl = geocode.Append(_openWeather.Site + _openWeather.GeoResponseType + _openWeather.GeoVersion)
                          .Append(_openWeather.GeolocationTemplate.Replace("cityname", cityName)
                          .Replace(",statecode", stateCode.HasValue ? stateCode.Value.ToString() : "")
                          .Replace(",countrycode", countryCode.HasValue ? countryCode.Value.ToString() : "")
                          .Replace("APIKey", _openWeather.Key)).ToString();

                var geoResponse = await _httpClient.GetAsync(geocodeUrl); // Make asynchronous call to Open Weather site

                if (!geoResponse.IsSuccessStatusCode || geoResponse == null || geoResponse.Content == null)
                {
                    return BadRequest("Call to Open Weather for geocode failed");
                }

                string geo = await geoResponse.Content.ReadAsStringAsync(); // Transform response to string
                var geoCode = JsonConvert.DeserializeObject<List<GeoCodeDto>>(geo);

                if (geoCode == null || geoCode == null || geoCode.Count == 0)
                {
                    return BadRequest("Deserialization of geocode failed");
                }

                var firstCity = geoCode.First();

                // if previous actions are successful - create url for five days weather forecast
                StringBuilder weatherUrl = new StringBuilder();
                string url = weatherUrl.Append(_openWeather.Site + _openWeather.WeatherResponseType + _openWeather.WeatherVersion)
                                 .Append(_openWeather.FiveDaysForecastTemplate.Replace("=lat", "=" + firstCity.Lat)
                                 .Replace("=lon", "=" + firstCity.Lon).Replace("APIKey", _openWeather.Key)).ToString();

                var response = await _httpClient.GetAsync(url); // Make asynchronous call to Open Weather site
                if (!response.IsSuccessStatusCode || response == null || response.Content == null)
                {
                    return BadRequest("Call to Open Weather for five days weather forecast failed");
                }

                string data = await response.Content.ReadAsStringAsync(); // Transform response to string
                var weather = JsonConvert.DeserializeObject<FiveDaysWeatherDto>(data);
                if (weather == null)
                {
                    return BadRequest("Deserialization of five days weather forecast failed");
                }

                return Ok(weather);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
