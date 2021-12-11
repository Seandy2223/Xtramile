using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xtramile.Base;
using Xtramile.Base.Interface;
using Xtramile.Model;

namespace Xtramile.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRequestService _request;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IFeature _feature;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFeature feature, IRequestService request)
        {
            _logger = logger;
            _request = request;
            _feature = feature;
        }

        [HttpGet]
        [Route("GetCountryList")]
        public async Task<string[]> GetCountryList()
        {
            var countryUrl = _feature.GetFeatureConfig("CountryUrl");

            var result = await _request.REST(countryUrl, RequestEnum.GET);
            if (result != null)
            {
                var response = await _request.ConvertResponseToEntity<CountryListAPI>(result);
                if (response.result.Count != 0)
                {
                    var country = response.result.OrderBy(m => m.name).Select(m => m.name).ToArray();
                    return country;
                }
            }
            return null;
        }

        [HttpPost]
        [Route("postCityList")]
        public async Task<string[]> postCityList()
        {
            var cityUrl = _feature.GetFeatureConfig("CityUrl");
            var countryReq = HttpContext.Request.Form["country"].ToString();
            var model = new CityPopulateAPI()
            {
                country = countryReq,
                order = "asc",
                orderBy = "name",
                limit = 10000
            };

            var result = await _request.REST(cityUrl, RequestEnum.POST, JsonConvert.SerializeObject(model));
            if (result != null)
            {
                var response = await _request.ConvertResponseToEntity<CityResponseAPI>(result);
                if (response.data.Count != 0)
                {
                    var country = response.data.OrderBy(m => m.city).Select(m => m.city).ToArray();
                    return country;
                }
            }

            return null;
        }

        [HttpPost]
        [Route("postCityWeather")]
        public async Task<WeatherForecast> postCityWeather()
        {
            var city = HttpContext.Request.Form["city"].ToString();

            try
            {
                var secretKey = _feature.GetFeatureConfig("ApiKey");
                var weatherUrl = _feature.GetFeatureConfig("WeatherUrl");

                var result = await _request.REST(weatherUrl + "/data/2.5/weather?q=" + city + "&units=imperial&appid=" + secretKey, RequestEnum.GET);
                if (result != null)
                {
                    var response = await _request.ConvertResponseToEntity<WeatherForecastAPI>(result);
                    if (response.Name != null)
                    {
                        return new WeatherForecast
                        {
                            Date = DateTime.UtcNow,
                            TemperatureF = (double)response.main.temp,
                            Location = response.Name,
                            Visibility = response.visibility,
                            Wind = response.wind.speed,
                            Pressure = response.main.pressure,
                            RelativeHumidity = response.main.humidity,
                            SkyConditions = response.weather[0].description,
                            Time = DateTime.UtcNow.AddSeconds(response.timezone)
                        };
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        [HttpGet]
        public string Get()
        {
            return "API Running";
        }
    }
}
