using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"------第{i}次请求------");
                //int result = DataSource.GetDataByDB(666);
                int result = 0;
                string key = "DataSource_GetDataByDB_666";
                //if(CacheHelper.Exsits(key))
                //{
                //    result = CacheHelper.Get<int>(key);
                //}
                //else
                //{
                //    result = DataSource.GetDataByDB(666);
                //    CacheHelper.Add(key, result);
                //}
                Func<int> func = new Func<int>(() => { return DataSource.GetDataByDB(666); });

                result = CacheHelper.GetCache(key, () => DataSource.GetDataByDB(666));
                Console.WriteLine($"第{i}此请求获取的数据为：{result}");
            }
            Console.ReadKey();
        }
    }
}
