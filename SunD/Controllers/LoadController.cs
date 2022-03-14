using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using RepositoryLibrary.Inteface;
using ServiceLibrary;
using ServiceLibrary.Interface;
using SunD.Models;
using System.Web;

namespace SunD.Controllers
{
    public class LoadController : Controller
    {

        private readonly IDataConvertService _dataConvertService;
        private readonly IWeatherRepository _weatherRepository;
        public LoadController(IDataConvertService dataConvertService, IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
            _dataConvertService = dataConvertService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Import(IFormFile[] file)
        {
            var wheaterStatistics = await _dataConvertService.ImportFromExcel(file);
            await _weatherRepository.SaveWeatherStatistic(wheaterStatistics);
            return RedirectToAction("Index");
        }
        
           
    }
}
