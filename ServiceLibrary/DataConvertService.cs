using BusinessObjects.Common;
using BusinessObjects.Model;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using ServiceLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public class DataConvertService : IDataConvertService
    {
        public async Task<List<WeatherStatistic>> ImportFromExcel(IFormFile[] file)
        {
            var list = new List<WeatherStatistic>();
            for (int i = 0; i < file.Length; i++)
            {
                using (var stream = new MemoryStream())
                {
                    await file[i].CopyToAsync(stream);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (var package = new ExcelPackage(stream))
                    {
                        for (int j = 0; j < package.Workbook.Worksheets.Count; j++)
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[j];
                            var rowcount = worksheet.Dimension.Rows;
                            for (int row = 5; row <= rowcount; row++)
                            {

                                var date = worksheet.Cells[row, 1].Value?.ToString()?.Trim();
                                var time = worksheet.Cells[row, 2].Value?.ToString()?.Trim();
                                var temperature = worksheet.Cells[row, 3].Value?.ToString()?.Trim();
                                var wetness = worksheet.Cells[row, 4].Value?.ToString()?.Trim();
                                var dewPoint = worksheet.Cells[row, 5].Value?.ToString()?.Trim();
                                var pressure = worksheet.Cells[row, 6].Value?.ToString()?.Trim();
                                var windDirection = worksheet.Cells[row, 7].Value?.ToString()?.Trim();
                                var windSpeed = worksheet.Cells[row, 8].Value?.ToString()?.Trim();
                                var cloudCover = worksheet.Cells[row, 9].Value?.ToString()?.Trim();
                                var lowerCloudCover = worksheet.Cells[row, 10].Value?.ToString()?.Trim();
                                var horizontalVisibility = worksheet.Cells[row, 11].Value?.ToString()?.Trim();
                                var natureInvent = worksheet.Cells[row, 12].Value?.ToString()?.Trim();


                                try
                                {
                                    list.Add(new WeatherStatistic
                                    {
                                        Date = Convert.ToDateTime(date),
                                        Time = Convert.ToDateTime(time),
                                        Temperature = !string.IsNullOrEmpty(temperature) ? Convert.ToDouble(temperature) : 0,
                                        Wetness = !string.IsNullOrEmpty(wetness) ? Convert.ToDouble(wetness) : 0,
                                        DewPoint = !string.IsNullOrEmpty(dewPoint) ? Convert.ToDouble(dewPoint) : 0,
                                        Pressure = !string.IsNullOrEmpty(pressure) ? Convert.ToInt32(pressure) : 0,
                                        WindDirection = windDirection,
                                        WindSpeed = !string.IsNullOrEmpty(windSpeed) ? Convert.ToInt32(windSpeed) : 0,
                                        CloudCover = !string.IsNullOrEmpty(cloudCover) ? Convert.ToInt32(cloudCover) : 0,
                                        LowerCloudCover = !string.IsNullOrEmpty(lowerCloudCover) ? Convert.ToInt32(lowerCloudCover) : 0,
                                        HorizontalVisibility = horizontalVisibility,
                                        NatureInvent = natureInvent
                                    });
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    return new List<WeatherStatistic>();
                                }

                            }
                        }
                    }
                }
            }
            return list;
        }
    }
}

