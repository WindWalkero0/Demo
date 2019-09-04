using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaculatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            int c = int.Parse(a) / int.Parse(b);
            Console.WriteLine(c.ToString());
            Console.WriteLine(DateTime.Now.ToString());
            Console.ReadKey();
        }
    }
}
