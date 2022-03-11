using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLibrary.Interface;
using SunD.Models;

namespace SunD.Controllers
{
    public class ViewingController : Controller
    {
        private readonly IWeatherService _weatherService;
        private  IEnumerable<MounthSelector> mouths;
        public ViewingController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
            mouths = GetMounthSelectors();
        }

        public IActionResult Index()
        {
            var data = new ViewningData()
            {
                MounthSelectors = mouths
            };

            return View(data);
        }
        
        [HttpGet]
        public IActionResult GetStatisticByMounth(int mounth)
        {
            var statistics = _weatherService.GetWeatherStatisticsByMounth(mounth);
            var data = new ViewningData() { MounthSelectors = mouths, WeatherStatistics = statistics };


            return View("Index", data);
        }

        [HttpGet]
        public IActionResult GetStatisticByYear(int year)
        {
            var statistics =  _weatherService.GetWeatherStatisticsByYear(year);
            var data = new ViewningData() { WeatherStatistics = statistics, MounthSelectors = mouths };

            return View("Index", data);
        }

        #region Private Methods
        private IEnumerable<MounthSelector> GetMounthSelectors()
        {
            var mounths = new List<MounthSelector>() { 
                new MounthSelector{Name="Январь", Value=1},
                new MounthSelector{Name="Февраль", Value=2},
                new MounthSelector{Name="Март", Value=3},
                new MounthSelector{Name="Апрель", Value=4},
                new MounthSelector{Name="Май", Value=5},
                new MounthSelector{Name="Июнь", Value=6},
                new MounthSelector{Name="Июль", Value=7},
                new MounthSelector{Name="Август", Value=8},
                new MounthSelector{Name="Сентябрь", Value=9},
                new MounthSelector{Name="Октябрь", Value=10},
                new MounthSelector{Name="Ноябрь", Value=11},
                new MounthSelector{Name="Декабрь", Value=12},
            };
            return mounths;
        }

        #endregion
    }
}
