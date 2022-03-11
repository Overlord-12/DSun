using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using ServiceLibrary;
using ServiceLibrary.Interface;
using SunD.Models;
using System.Web;

namespace SunD.Controllers
{
    public class LoadController : Controller
    {

        private readonly IDataConvertService _dataConvertService;
        private readonly IWeatherService _weatherService;
        public LoadController(IDataConvertService dataConvertService, IWeatherService weatherService)
        {
            _weatherService = weatherService;
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
            await _weatherService.SaveWheatherStatistic(wheaterStatistics);
            return RedirectToAction("Index");
        }
        
           
    }
}
