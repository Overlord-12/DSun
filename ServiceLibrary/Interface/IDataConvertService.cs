using BusinessObjects.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary.Interface
{
    public interface IDataConvertService
    {
        public  Task<List<WeatherStatistic>> ImportFromExcel(IFormFile[] file);
    }
}
