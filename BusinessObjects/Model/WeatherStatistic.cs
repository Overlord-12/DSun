using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Model
{
    public class WeatherStatistic
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public double Temperature { get; set; }
        public double Wetness { get; set; }
        public double DewPoint { get; set; }
        public int Pressure { get; set; }
        public string? WindDirection { get; set; }
        public int? WindSpeed { get; set; }
        public int? CloudCover { get;set; }
        public int LowerCloudCover { get;set; }
        public string? HorizontalVisibility { get; set; }
        public string? NatureInvent { get; set; }



    }
}
