// <copyright file="CacheT.cs" company="Nilorn Group">
// Copyright (c) Nilorn Group. All rights reserved.
// </copyright>

using Microsoft.Extensions.Caching.Memory;

namespace WebApi.Expansion
{
    /// <summary>
    /// https://michaelscodingspot.com/cache-implementations-in-csharp-net/
    /// </summary>
    /// <typeparam name="TItem">Коллекция</typeparam>
    public class CacheT<TItem>
    {
        private readonly MemoryCache cache = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// Метод Get для работы с коллекциями
        /// </summary>
        /// <param name="key"> Имя объекта</param>
        /// <param name="item">Значение</param>
        /// <returns>Коллекцию или false</returns>
        public TItem Get(object key, TItem item)
        {
            if (!this.cache.TryGetValue(key, out TItem cacheEntry))
            {
                cacheEntry = item;
            }

            return cacheEntry;
        }

        public void Set(object key, TItem item)
        {
            this.cache.Set(key, item);
        }

        public void Clean(object key)
        {
            this.cache.Remove(key);
        }
    }
}
