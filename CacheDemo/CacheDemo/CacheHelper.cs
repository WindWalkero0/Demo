using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheDemo
{
    public class CacheHelper
    {
        private static Dictionary<string, object> CacheDictionary = new Dictionary<string, object>();

        public static void Add(string key, object value)
        {
            CacheDictionary.Add(key, value);
        }

        public static T Get<T>(string key)
        {
            return (T)CacheDictionary[key];
        }

        public static bool Exsits(string key)
        {
            return CacheDictionary.ContainsKey(key);
        }

        public static T GetCache<T>(string key, Func<T> func)
        {
            T t = default(T);
            if (CacheHelper.Exsits(key))
            {
                t = CacheHelper.Get<T>(key);
            }
            else
            {
                t = func.Invoke();
                CacheHelper.Add(key, t);
            }
            return t;
        }
    }
}
