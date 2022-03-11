using BusinessObjects.Model;
using RepositoryLibrary.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary.Interface
{
    public class WeatherService : IWeatherService
    {
        private IWeatherRepository _weatherRepository;
        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public IEnumerable<WeatherStatistic> GetWeatherStatisticsByMounth(int numberOfMounth)
        {
            return _weatherRepository.GetWeatherStatisticsByMounth(numberOfMounth);
        }

        public IEnumerable<WeatherStatistic> GetWeatherStatisticsByYear(int year)
        {
            return _weatherRepository.GetWeatherStatisticsByYear(year);
        }

        public async Task SaveWheatherStatistic(List<WeatherStatistic> wheather)
        {
             await _weatherRepository.SaveWeatherStatistic(wheather);
        }
    }
}
