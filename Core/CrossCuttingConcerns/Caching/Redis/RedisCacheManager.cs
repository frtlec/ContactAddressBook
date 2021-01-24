using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using StackExchange.Redis;
using Core.Extensions;
using Microsoft.Extensions.Configuration;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private IDistributedCache _distributedCache;
        private ConnectionMultiplexer _connectionMultiplexer;
        private IConfiguration Configration { get; }
        private string connString { get; set; }
        public RedisCacheManager(IConfiguration configration)
        {

            _distributedCache = ServiceTool.ServiceProvider.GetService<IDistributedCache>();
            Configration = configration;
            connString = Configration.GetSection("RedisConfiguration").Value;
            _connectionMultiplexer = ConnectionMultiplexer.Connect(connString);
       
        }
        public void Add(string key, object data, int duration)
        {
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(duration)
            };
            
            _distributedCache.Set(key, data.ToByteArray(), cacheOptions);
        }


        public T Get<T>(string key)
        {
            
            return default(T);
        }

        public object Get(string key)
        {
            return _distributedCache.Get(key)?.ToObject();

        }

        public bool IsAdd(string key)
        {
            var valueString = _distributedCache.GetString(key);
            if (!string.IsNullOrEmpty(valueString))
            {
                return true;
            }
            return false;
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(pattern));

            var server = _connectionMultiplexer.GetServer(connString);
            var keys = server.Keys(pattern: pattern);
            foreach (var key in keys)
            {
                _distributedCache.Remove(key);
            }
        }
    }
}
