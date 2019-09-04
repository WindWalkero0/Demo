using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    class GenericClass
    {
    }
    public class DataQuery<T> where T:class, new ()
    {
        private Random rand = new Random();
        private int rows = 0;

        public DataQuery()
        {
            this.rows = rand.Next(1, 10);//随机生成1-10个对象
        }

        public IEnumerable<T> Query()
        {
            for(int i = 0; i < rows; i++)
            {
                T item = new T();
                yield return item;
            }
        }
    }

    public class DataItem
    {
        public DataItem()
        {
            Console.WriteLine("DataItem created.");
        }
    }
}
