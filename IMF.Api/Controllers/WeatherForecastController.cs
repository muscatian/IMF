using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using IMF.Api.Services;
using IMF.Api;

namespace IMF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var clientIp = HttpContext.Connection.RemoteIpAddress?.ToString();
            var machineName = Environment.MachineName;
            string userName = UsersService.GetLoginUser(HttpContext);

            _logger.LogInformation("Client IP: {ClientIp}, Machine Name: {MachineName}, User Name: {UserName}", clientIp, machineName, userName);
            
            //_logger.LogDebug("Returning weather forecast for the {days} days after today: {@forecast}",  days,    forecast);

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
