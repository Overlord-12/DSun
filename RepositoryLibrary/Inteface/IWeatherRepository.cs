using BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrary.Inteface
{
    public interface IWeatherRepository
    {
        public Task SaveWeatherStatistic(List<WeatherStatistic> wheather);
        public List<WeatherStatistic> GetWeatherStatistic();
        public IEnumerable<WeatherStatistic> GetWeatherStatisticsByMounth(int numberOfMounth);
        public IEnumerable<WeatherStatistic> GetWeatherStatisticsByYear(int year);
    }
}
