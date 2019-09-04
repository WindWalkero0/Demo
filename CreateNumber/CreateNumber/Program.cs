using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 424;
            int j = 10;
            Console.WriteLine(String.Format("{0:D" + j + "}", i));
            Console.ReadKey();
        }
    }
}
