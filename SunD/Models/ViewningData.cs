using BusinessObjects.Model;

namespace SunD.Models
{
    public class ViewningData
    {
        public IEnumerable<MounthSelector> MounthSelectors { get; set; } = null!;
        public IEnumerable<WeatherStatistic>? WeatherStatistics { get; set; }
    }
}
