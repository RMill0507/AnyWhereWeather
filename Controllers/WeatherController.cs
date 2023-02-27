using Microsoft.AspNetCore.Mvc;

namespace AnyWhereWeather.Controllers
{
    public class WeatherController : Controller
    {
        private readonly APIClient _client;
            
        public WeatherController(APIClient client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetWeather(string zip)
        {
            var weather = _client.GetTheWeather(zip);
            return View(weather);
        }
    }
}
