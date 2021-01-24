
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Caching.Redis;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        private IConfiguration Configration { get; }
        public CoreModule(IConfiguration configration)
        {
            this.Configration = configration;
        }
        public void Load(IServiceCollection services)
        {
            //services.AddMemoryCache();
            services.AddStackExchangeRedisCache(opt => {
                opt.Configuration = Configration.GetSection("RedisConfiguration").Value;
            });
            services.AddSingleton<ICacheManager, RedisCacheManager>();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<Stopwatch>();
        }
    }
}
