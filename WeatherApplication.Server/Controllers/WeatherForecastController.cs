using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json; // You need to install Newtonsoft.Json nugget package 
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;
using WeatherApplication.Server.Data;
using WeatherApplication.Server.DTOs;
using WeatherApplication.Server.DTOs.CurrentWeather;
using WeatherApplication.Server.DTOs.FiveDaysWeather;
using WeatherApplication.Server.Interfaces;
using WeatherApplication.Server.Models;

namespace WeatherApplication.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly OpenWeather _openWeather;
        private readonly HttpClient _httpClient;
        private ApplicationDbContext _context;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUrlBuilderInterface _urlBuilder;
        private readonly ITenantFinderInterface _tenantFinder;
        private readonly IMapper _mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IOptions<OpenWeather> openWeather,
            IHttpClientFactory httpClientFactory,
            IUrlBuilderInterface urlBuilder, 
            ApplicationDbContext context,
            ITenantFinderInterface tenantFinder,
            IMapper mapper)
        {
            _httpClient = httpClientFactory.CreateClient("OpenWeatherClient"); // Use DI to get HTTPClient correctly
            _openWeather = openWeather.Value;
            _urlBuilder = urlBuilder;
            _logger = logger;
            _context = context;
            _tenantFinder = tenantFinder;
            _mapper = mapper;
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
        public async Task<ActionResult<CurrentWeatherDto>> GetCurrentWeather([FromQuery][Required] string cityName,
                                                                             [FromQuery][Required] string userEmail, 
                                                                             [FromQuery] int? stateCode,
                                                                             [FromQuery] int? countryCode)
        {
            try
            {
                // Check if we got required data at all
                if (_openWeather == null || string.IsNullOrWhiteSpace(cityName) || string.IsNullOrWhiteSpace(userEmail))
                {
                    return BadRequest("Some configuration or request is empty"); // Return bad request with message that points to problem
                }

                Guid tenantId = await _tenantFinder.GetTenantId(userEmail, _context);

                if(tenantId == default)
                {
                    return Unauthorized("You are not authorized to perform any action");
                }

                string geocodeUrl = _urlBuilder.GetGeocodeUrl(_openWeather, cityName, stateCode, countryCode);

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

                var call = _mapper.Map<CurrentWeather>(currentWeather, opts =>
                {
                    opts.Items[nameof(CurrentWeather.TenantId)] = tenantId;
                });

                await _context.AddAsync(call);
                await _context.SaveChangesAsync();

                var record = _mapper.Map<Record>(firstCity, opts =>
                {
                    opts.Items[nameof(Record.TenantId)] = tenantId;
                    opts.Items[nameof(Record.CurrentWeatherId)] = call.Id;
                    opts.Items[nameof(Record.FiveDaysWeatherId)] = null;
                });

                await _context.AddAsync(record);
                await _context.SaveChangesAsync();

                return Ok(currentWeather);
            }
            catch(Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FiveDaysWeather")]
        public async Task<ActionResult<FiveDaysWeatherDto>> GetFiveDaysWeather([FromQuery][Required] string cityName,
                                                                               [FromQuery][Required] string userEmail,
                                                                               [FromQuery] int? stateCode,
                                                                               [FromQuery] int? countryCode)
        {
            try
            {
                // Check if we got required data at all
                if (_openWeather == null || string.IsNullOrWhiteSpace(cityName) || string.IsNullOrWhiteSpace(userEmail))
                {
                    return BadRequest("Some configuration or request is empty"); // Return bad request with message that points to problem
                }

                Guid tenantId = await _tenantFinder.GetTenantId(userEmail, _context);

                if (tenantId == default)
                {
                    return Unauthorized("You are not authorized to perform any action");
                }

                string geocodeUrl = _urlBuilder.GetGeocodeUrl(_openWeather, cityName, stateCode, countryCode);

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
                string url = _urlBuilder.GetWeatherUrl(_openWeather.FiveDaysForecastTemplate, firstCity, _openWeather);

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
                                
                var call = _mapper.Map<FiveDaysWeather>(weather, opts =>
                {
                    opts.Items[nameof(FiveDaysWeather.TenantId)] = tenantId;
                    opts.Items[nameof(FiveDaysWeather.Items)] = null;
                });
                
                var items = weather?.List?.Select(x =>
                {
                    var item = _mapper.Map<Item>(x, opts =>
                    {
                        opts.Items[nameof(Item.FiveDaysWeatherId)] = call.Id;
                        opts.Items[nameof(Item.FiveDaysWeather)] = call;
                    });

                    return item;
                });
                
                if (items != null)
                {
                    await _context.AddRangeAsync(items);
                    await _context.SaveChangesAsync();
                }

                var record = _mapper.Map<Record>(firstCity, opts =>
                {
                    opts.Items[nameof(Record.TenantId)] = tenantId;
                    opts.Items[nameof(Record.CurrentWeatherId)] = null;
                    opts.Items[nameof(Record.FiveDaysWeatherId)] = call.Id;
                });

                await _context.AddAsync(record);
                await _context.SaveChangesAsync();

                return Ok(weather);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllRecordsForTenant")]
        public async Task<ActionResult<IEnumerable<Record>>> GetAllRecordsForTenant([FromQuery][Required] string userEmail)
        {
            if (_openWeather == null)
            {
                return BadRequest("Some configuration or request is empty");
            }

            Guid tenantId = await _tenantFinder.GetTenantId(userEmail, _context);

            if (tenantId == default)
            {
                return Unauthorized("You are not authorized to perform any action");
            }
            var records = await _context.Records.Include(x => x.CurrentWeather)
                                          .Include(x => x.FiveDaysWeather).ThenInclude(x => x!.Items)
                                          .Where(x => x.TenantId == tenantId)
                                          .ToListAsync();
            return Ok(records);
        }

        [HttpPost("SeedDefaultTenantsAndUsers")]
        public async Task<ActionResult> SeedDefaultTenantsAndUsers()
        {
            int result = 0;
            List<Tenant> tenants = new List<Tenant>
            {
                new Tenant
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Name = "Agroworld"
                },
                new Tenant
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Name = "Translogistic"
                },
                new Tenant
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Name = "HuntSeason"
                },
                new Tenant
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Name = "Fisher"
                }
            };

            if(!_context.Tenants.Any())
            {
                await _context.AddRangeAsync(tenants);
                result += await _context.SaveChangesAsync();
                tenants = await _context.Tenants.ToListAsync();
            }

            List<User> users = new List<User>()
            {
                new User
                {
                    Id = Guid.NewGuid(), 
                    CreatedAt = DateTime.Now,
                    Name = "Albert",
                    Email = "albert@gmail.com",
                    Address = "Lviv",
                    TenantId = tenants.First(x => x.Name == "Agroworld").Id
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Name = "Andy",
                    Email = "andy@gmail.com",
                    Address = "Damask",
                    TenantId = tenants.First(x => x.Name == "Translogistic").Id
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Name = "Conrad",
                    Email = "conrad@gmail.com",
                    Address = "Donetsk",
                    TenantId = tenants.First(x => x.Name == "HuntSeason").Id
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Name = "Donald",
                    Email = "donald@gmail.com",
                    Address = "Kyiv",
                    TenantId = tenants.First(x => x.Name == "Fisher").Id
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Name = "John",
                    Email = "John@gmail.com",
                    Address = "Krakiw",
                    TenantId = tenants.First(x => x.Name == "Agroworld").Id
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Name = "Dean",
                    Email = "dean@gmail.com",
                    Address = "Kherson",
                    TenantId = tenants.First(x => x.Name == "HuntSeason").Id
                }
            };

            if (!_context.Users.Any())
            {
                await _context.AddRangeAsync(users);
                result +=await _context.SaveChangesAsync();                
            }

            if(result == 0)
            {
                return BadRequest($"Seed method affected {result} rows in the database");
            }
            return Ok($"Seed method affected {result} rows in the database");
        }

    }
}
