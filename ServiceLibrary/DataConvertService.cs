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
                                try
                                {
                                    list.Add(new WeatherStatistic
                                    {
                                        Date = Convert.ToDateTime(worksheet.Cells[row, 1].Value?.ToString()?.Trim()),
                                        Time = Convert.ToDateTime(worksheet.Cells[row, 2].Value?.ToString()?.Trim()),
                                        Temperature = !string.IsNullOrEmpty(worksheet.Cells[row, 3].Value?.ToString()?.Trim())
                                        ? Convert.ToDouble(worksheet.Cells[row, 3].Value?.ToString()?.Trim()) : 0,
                                        Wetness = !string.IsNullOrEmpty(worksheet.Cells[row, 4].Value?.ToString()?.Trim()) 
                                        ? Convert.ToDouble(worksheet.Cells[row, 4].Value?.ToString()?.Trim()) : 0,
                                        DewPoint = !string.IsNullOrEmpty(worksheet.Cells[row, 5].Value?.ToString()?.Trim()) ? 
                                        Convert.ToDouble(worksheet.Cells[row, 5].Value?.ToString()?.Trim()) : 0,
                                        Pressure = !string.IsNullOrEmpty(worksheet.Cells[row, 6].Value?.ToString()?.Trim()) 
                                        ? Convert.ToInt32(worksheet.Cells[row, 6].Value?.ToString()?.Trim()) : 0,
                                        WindDirection = worksheet.Cells[row, 8].Value?.ToString()?.Trim(),
                                        WindSpeed = !string.IsNullOrEmpty(worksheet.Cells[row, 8].Value?.ToString()?.Trim())
                                        ? Convert.ToInt32(worksheet.Cells[row, 8].Value?.ToString()?.Trim()) : 0,
                                        CloudCover = !string.IsNullOrEmpty(worksheet.Cells[row, 9].Value?.ToString()?.Trim()) 
                                        ? Convert.ToInt32(worksheet.Cells[row, 9].Value?.ToString()?.Trim()) : 0,
                                        LowerCloudCover = !string.IsNullOrEmpty(worksheet.Cells[row, 10].Value?.ToString()?.Trim()) 
                                        ? Convert.ToInt32(worksheet.Cells[row, 10].Value?.ToString()?.Trim()) : 0,
                                        HorizontalVisibility = worksheet.Cells[row, 11].Value?.ToString()?.Trim(),
                                        NatureInvent = worksheet.Cells[row, 12].Value?.ToString()?.Trim()
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

