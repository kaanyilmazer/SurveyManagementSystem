using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey,object response, TimeSpan timeLive);
        Task<string>  GetCacheResponseAsync(string cacheKey);
    }
}
