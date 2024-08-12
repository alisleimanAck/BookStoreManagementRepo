using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApi.Controllers
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

        // GET /weatherforecast
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return WeatherForecasts;
        }

        // POST /weatherforecast
        [HttpPost]
        public IActionResult Post([FromBody] WeatherForecast forecast)
        {
            WeatherForecasts.Add(forecast);
            return CreatedAtAction(nameof(Get), new { date = forecast.Date }, forecast);
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
    }
}
