using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Serilog;

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
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     _logger.LogInformation("Handling GET request");
        //     return WeatherForecasts;
        // }

        // POST /weatherforecast
        [HttpPost]
        public IActionResult Post([FromBody] WeatherForecast forecast)
        {
            _logger.LogInformation("Handling POST request with data: {@forecast}", forecast);
            WeatherForecasts.Add(forecast);
            return CreatedAtAction(nameof(Get), new { date = forecast.Date }, forecast);
        }

        // PUT /weatherforecast/{date}
        [HttpPut("{date}")]
        public IActionResult Put(DateOnly date, [FromBody] WeatherForecast updatedForecast)
        {
            _logger.LogInformation("Handling PUT request for date: {date}", date);
            var forecast = WeatherForecasts.FirstOrDefault(wf => wf.Date == date);
            if (forecast == null)
            {
                _logger.LogWarning("No forecast found for date: {date}", date);
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
            _logger.LogInformation("Handling DELETE request for date: {date}", date);
            var forecast = WeatherForecasts.FirstOrDefault(wf => wf.Date == date);
            if (forecast == null)
            {
                _logger.LogWarning("No forecast found for date: {date}", date);
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
