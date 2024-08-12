using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly List<WeatherForecast> WeatherForecasts = new List<WeatherForecast>();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // GET /weatherforecast
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
         //   return WeatherForecasts;
        }

        [HttpGet]
        public IActionResult ThrowError([FromQuery] int errorCode)
        {
            switch (errorCode)
            {
                case 400:
                    throw new ExecutionContext
                case 401:
                    throw new UnauthorizedAccessException();
                case 404:
                    throw new NotFoundException("");
                default:
                    throw new NullReferenceException();
            }
        }

        // POST /weatherforecast
        [HttpPost]
        public IActionResult Post([FromBody] WeatherForecast forecast)
        {
            WeatherForecasts.Add(forecast);
            return Ok(forecast);
        }

        // PUT /weatherforecast/{date}
        [HttpPut("{date}")]
        public IActionResult Put(DateOnly date, [FromBody] WeatherForecast updatedForecast)
        {
            var forecast = WeatherForecasts.FirstOrDefault(wf => wf.Date == date);
            if (forecast == null)
            {
                return NotFound();
            }
            WeatherForecasts.Remove(forecast);
            WeatherForecasts.Add(updatedForecast with { Date = date });
            return NoContent();
        }

        // DELETE /weatherforecast/{date}
        [HttpDelete("{date}")]
        public IActionResult Delete(DateOnly date)
        {
            var forecast = WeatherForecasts.FirstOrDefault(wf => wf.Date == date);
            if (forecast == null)
            {
                return NotFound();
            }
            WeatherForecasts.Remove(forecast);
            return NoContent();
        }
    }

    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
