using BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary.Interface
{
    public interface IWeatherService
    {
        public Task SaveWheatherStatistic(List<WeatherStatistic> wheather);
        public IEnumerable<WeatherStatistic> GetWeatherStatisticsByMounth(int numberOfMounth);
        public IEnumerable<WeatherStatistic> GetWeatherStatisticsByYear(int year);
    }
}
