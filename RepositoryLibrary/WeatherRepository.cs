using BusinessObjects;
using BusinessObjects.Model;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<WeatherStatistic>> GetWeatherStatistic()
        {
            return await _context.WeatherStatistics.ToListAsync();
        }

        public async Task<IEnumerable<WeatherStatistic>> GetWeatherStatisticsByMounth(int numberOfMounth)
        {
            return await _context.WeatherStatistics.Where(x => x.Date.Month == numberOfMounth).ToListAsync();
        }

        public async Task<IEnumerable<WeatherStatistic>> GetWeatherStatisticsByYear(int year)
        {
            return await _context.WeatherStatistics.Where(x => x.Date.Year == year).OrderBy(p=>p.Temperature).ToListAsync();
        }

        public async Task SaveWeatherStatistic(List<WeatherStatistic> wheather)
        {
            await _context.AddRangeAsync(wheather);
            await _context.SaveChangesAsync();
        }
    }
}
