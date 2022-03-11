using Microsoft.Extensions.DependencyInjection;
using RepositoryLibrary.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCFactory
{
    public static class ServiceCollectionExtensionRepository
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IWeatherRepository, WeatherRepository>();
            return services;
        }
    }
}
