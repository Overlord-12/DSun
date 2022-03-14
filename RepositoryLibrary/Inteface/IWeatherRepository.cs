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
        public Task<List<WeatherStatistic>> GetWeatherStatistic();
        public Task<IEnumerable<WeatherStatistic>> GetWeatherStatisticsByMounth(int numberOfMounth);
        public Task<IEnumerable<WeatherStatistic>> GetWeatherStatisticsByYear(int year);
    }
}
