using BusinessObjects.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReflectionIT.Mvc.Paging;
using RepositoryLibrary.Inteface;
using ServiceLibrary.Interface;
using SunD.Models;

namespace SunD.Controllers
{
    public class ViewingController : Controller
    {
        private readonly IWeatherRepository _weatherRepository;
        private IEnumerable<MounthSelector> mouths;
        private const int pageSize = 20;
        public ViewingController(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
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
        public async Task<IActionResult> GetStatisticByMounth(int mounth)
        {
            var statistics = await _weatherRepository.GetWeatherStatisticsByMounth(mounth);
            StaticWeather.WeatherStatistics = statistics;
            var data = GetData(statistics);

            return View("Index", data);
        }


        [HttpGet]
        public async Task<IActionResult> GetStatisticByYear(int year)
        {
            var statistics = await _weatherRepository.GetWeatherStatisticsByYear(year);
            StaticWeather.WeatherStatistics = statistics;
            var data = GetData(statistics);

            return View("Index", data);
        }

        public async Task<IActionResult> ChangePage(int page )
        {

            var statistics = StaticWeather.WeatherStatistics;
            var count = statistics.Count();
            var items = statistics.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            var data = new ViewningData() { WeatherStatistics = items, MounthSelectors = mouths, PageViewModel = pageViewModel };


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
        private ViewningData GetData(IEnumerable<WeatherStatistic> statistics)
        {
            var count = statistics.Count();
            int page = 1;
            var items = statistics.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            var data = new ViewningData() { WeatherStatistics = items, MounthSelectors = mouths, PageViewModel = pageViewModel };

            return data;
        }

        #endregion
    }
}
