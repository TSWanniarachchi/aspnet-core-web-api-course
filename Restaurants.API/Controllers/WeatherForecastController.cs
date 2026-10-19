using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers
{
    public class TemperatureRequest
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }


    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        [Route("{take}/example")]
        public IActionResult Get([FromQuery] int max, [FromRoute] int take)
        {
            var result = _weatherForecastService.Get();
            //Response.StatusCode = 400;
            //return StatusCode(400, result);
            return BadRequest(result);
        }

        [HttpGet("currentDay")]
        public WeatherForecast GetCurrentDayForecast()
        {
            var result = _weatherForecastService.Get().First();
            return result;
        }

        [HttpPost]
        public string Hello([FromBody] string name)
        {
            return $"Hello {name}";
        }

        [HttpPost]
        [Route("genarate")]
        public IActionResult Genarate([FromQuery] int count, [FromBody] TemperatureRequest request)
        {
            if (count < 0 || request.Max < request.Min)
                return BadRequest("Count has to be postive number, and max must be greater than the min value");

            var result = _weatherForecastService.Get(count, request.Min, request.Max);
            return Ok(result);
        }
    }
}
