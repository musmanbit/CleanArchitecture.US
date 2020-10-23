using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.US.Common.NLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.US.API.Authentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        protected readonly ILoggerManager _loggerManager;
        public WeatherForecastController(ILoggerManager logger)
        {
            _loggerManager = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                _loggerManager.LogEnter();
                _loggerManager.LogDebug("Log Debug");
                _loggerManager.LogInformation("Log info");
                _loggerManager.LogWarning("Log warning");
                int i = 5;
                int d = 0;
                Console.WriteLine((i / d).ToString());

                var rng = new Random();
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
            }
            finally
            {
                _loggerManager.LogExit ();
            }
        }
    }
}
