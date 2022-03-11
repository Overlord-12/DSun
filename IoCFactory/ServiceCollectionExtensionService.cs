using Microsoft.Extensions.DependencyInjection;
using ServiceLibrary;
using ServiceLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCFactory
{
    public static class ServiceCollectionExtensionService
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddTransient<IDataConvertService, DataConvertService>();
            services.AddTransient<IWeatherService, WeatherService>();
            return services;
        }
    }
}
