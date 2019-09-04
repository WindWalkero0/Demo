using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DataQuery<DataItem> query = new DataQuery<DataItem>();
            query.Query().ToList();
            Console.ReadLine();
        }
    }
}
