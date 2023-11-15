using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly SyncDirector _director;

        public WeatherForecastController(SyncDirector director)
        {
            _director = director;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            var result = _director.Initiate(new AuthorizationLevel("Admin"));

            return result.Result.Message;
        }
    }
}
