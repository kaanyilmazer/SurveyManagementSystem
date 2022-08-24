using Core.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Service.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IOptions<RedisCacheSettings> _redisCacheSettings;

        public ResponseCacheService(IDistributedCache distributedCache, IOptions<RedisCacheSettings> redisCacheSettings)
        {
            _distributedCache = distributedCache;
            _redisCacheSettings = redisCacheSettings;
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeLive)
        {
            if (response == null)
            {
                return;
            }
            var serializedResponse = JsonConvert.SerializeObject(response);
            await _distributedCache.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeLive
            });
        }

        public async Task<string> GetCacheResponseAsync(string cacheKey)
        {
            var cachedResponse = await _distributedCache.GetStringAsync(cacheKey);
            return string.IsNullOrEmpty(cachedResponse) ? null : cachedResponse;
        }
    }
}
