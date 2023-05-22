using System;
using System.Runtime.Caching;

namespace Repositories
{
    internal class Cache
    {
        private static readonly ObjectCache cache = MemoryCache.Default;

        public static object Get(string chave)
        {
            return cache.Get(chave);
        }

        public static void Set(string chave, object valor, int minutos)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(minutos);
            cache.Set(chave, valor, policy);
        }

        public static void Set(string chave, object valor)
        {
            cache.Set(chave, valor, null);
        }

        public static void Remove(string chave)
        {
            cache.Remove(chave);
        }
    }
}
