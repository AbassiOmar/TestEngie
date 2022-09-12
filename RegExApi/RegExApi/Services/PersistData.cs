using Microsoft.Extensions.Caching.Memory;
using RegExModels.Models.Output;
using ServicesRegEx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RegExApi.Services
{
    public class PersistData: IPersistData
    {
        private readonly IMemoryCache _memoryCache;
        public PersistData(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void SetData(ResponseMatching responseMatching)
        {
            _memoryCache.Set("Matching - " + DateTime.UtcNow, responseMatching);
        }

        public List<ResponseMatching> GetData()
        {
            var keys = GetAllKeysList(_memoryCache);
            List<ResponseMatching> responseMatching = new List<ResponseMatching>(0);
            foreach (var key in keys)
            {
                if (_memoryCache.TryGetValue<ResponseMatching>(key, out ResponseMatching response))
                {
                    responseMatching.Add(response);
                }

            }
            return responseMatching;
        }

        private static List<string> GetAllKeysList(IMemoryCache cache)
        {
            var field = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
            var collection = field.GetValue(cache) as ICollection;
            var items = new List<string>();
            if (collection != null)
                foreach (var item in collection)
                {
                    var methodInfo = item.GetType().GetProperty("Key");
                    var val = methodInfo.GetValue(item);
                    items.Add(val.ToString());
                }
            return items;
        }
    }
}
