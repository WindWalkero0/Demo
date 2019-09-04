using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "1 2 3 456\n78 9";

            string path = $@"123" +
@"{Environment.CurrentDirectory}\\123";
            string str1 = @"12345655555555
555";
            str = str.Replace(" ", "").Replace("\n", "").Replace("\r", "");
            Console.WriteLine(str);
            Console.WriteLine(str1);
            Console.WriteLine(path);
            Console.Read();
        }
    }
}
