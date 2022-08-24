using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Dtos;

namespace Service.Services
{
    public class CacheInstaller : IInstaller
    {
      
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<RedisCacheSettings>();
            var redisCacheSettings = new RedisCacheSettings();
            configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSettings);
            services.AddSingleton(redisCacheSettings);

            if (!redisCacheSettings.Enabled)
            {
                return;
            }
            services.AddStackExchangeRedisCache(opt => opt.Configuration = redisCacheSettings.ConnectionString);
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();

            

        }
    }
}
