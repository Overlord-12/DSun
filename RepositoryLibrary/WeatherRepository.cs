using BusinessObjects;
using BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrary.Inteface
{
    public class WeatherRepository : IWeatherRepository
    {
        private DataBaseContext _context;
        public WeatherRepository(DataBaseContext context)
        {
            _context = context;
        }

        public List<WeatherStatistic> GetWeatherStatistic()
        {
            return _context.WeatherStatistics.ToList();
        }

        public IEnumerable<WeatherStatistic> GetWeatherStatisticsByMounth(int numberOfMounth)
        {
            var test = _context.WeatherStatistics.ToList();
            return _context.WeatherStatistics.Where(x => x.Date.Month == numberOfMounth).ToList();
        }

        public IEnumerable<WeatherStatistic> GetWeatherStatisticsByYear(int year)
        {
            var test = _context.WeatherStatistics.Where(x => x.Date.Year == year).ToList();
            return _context.WeatherStatistics.ToList().Where(x=>x.Date.Year == year);
        }

        public async Task SaveWeatherStatistic(List<WeatherStatistic> wheather)
        {
            await _context.AddRangeAsync(wheather);
            await _context.SaveChangesAsync();
        }
    }
}
