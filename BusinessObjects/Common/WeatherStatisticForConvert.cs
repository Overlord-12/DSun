using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Common
{
    public class WeatherStatisticForConvert
    {
        public string? Date { get; set; }
        public string? Time { get; set; }
        public string? Temperature { get; set; }
        public string? Wetness { get; set; }
        public string? DewPoint { get; set; }
        public string? Pressure { get; set; }
        public string? WindDirection { get; set; }
        public string? WindSpeed { get; set; }
        public string? CloudCover { get; set; }
        public string? LowerCloudCover { get; set; }
        public string? HorizontalVisibility { get; set; }
        public string? NatureInvent { get; set; }
    }
}
