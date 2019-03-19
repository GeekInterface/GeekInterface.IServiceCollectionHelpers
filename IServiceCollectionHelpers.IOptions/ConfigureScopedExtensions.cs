using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekInterface.IServiceCollectionHelpers.IOptions
{
    public static class ConfigureScopedExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="collection"></param>
        /// <param name="configSection"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureTransient<TService, TImplementation>(this IServiceCollection collection, IConfigurationSection configSection)
         where TService : class
         where TImplementation : class, TService, new()
        {
            collection.Configure<TImplementation>(configSection);
            collection.AddScoped<TService, TImplementation>(x => collection.BuildServiceProvider().GetService<IOptions<TImplementation>>().Value);

            return collection;
        }
    }
}
