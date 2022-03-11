using BusinessObjects.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class DataBaseContext : DbContext
    {
        public DbSet<WeatherStatistic>? WeatherStatistics { get; private set; }

        public DataBaseContext(DbContextOptions options):base(options)
        {
        }
    }
}
