using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using BlazorApp.Shared;

namespace BlazorApp.Api
{
    public class WeatherForecastService
    {
        public Task<WeatherForecast[]> stadt(DateTime startDate, String stadt)
        {
            var client = new OpenWeatherAPI.API("b9ae2332feb67e597cae025895d7b866");
            var results_stadt = client.Query(stadt);

            return Task.FromResult(Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {

                Location = stadt,
                Date = startDate.AddDays(index),
                TemperatureC = results_stadt.Main.Temperature.CelsiusCurrent,
                Humdity = results_stadt.Main.Humdity,
                Pressure = results_stadt.Main.Pressure,
                //H3 = results_stadt.Rain.H3,
                Clouds = results_stadt.Clouds.All,
                Wind_Speed = results_stadt.Wind.SpeedMetersPerSecond,
                Wind_Direction = results_stadt.Wind.Degree

            }).ToArray());
        }


        public WeatherForecast[] stadt_arrow(String stadt_user)
        {
            var task = stadt(DateTime.UtcNow, stadt_user);
            WeatherForecast[] result = task.Result;
            return result;
        }


        public WeatherForecast lol(String stadt)
        {
            var client = new OpenWeatherAPI.API("b9ae2332feb67e597cae025895d7b866");
            var results_stadt = client.Query(stadt);


            WeatherForecast temp = new WeatherForecast()
            {
                Location = stadt,
                Date = DateTime.UtcNow,
                TemperatureC = results_stadt.Main.Temperature.CelsiusCurrent,
                Humdity = results_stadt.Main.Humdity,
                Pressure = results_stadt.Main.Pressure,
                //H3 = results_stadt.Rain.H3,
                Clouds = results_stadt.Clouds.All,
                Wind_Speed = results_stadt.Wind.SpeedMetersPerSecond,
                Wind_Direction = results_stadt.Wind.Degree,
                //Wind_Direction_Str = results_stadt.Wind.DirectionEnum.Direction

            };

            return temp;

        }
    }
}

        [FunctionName("WeatherForecast")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var randomNumber = new Random();
            var temp = 0;

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = temp = randomNumber.Next(-20, 55),
                Summary = GetSummary(temp)
            }).ToArray();

            return new OkObjectResult(result);
        }
    }
}
