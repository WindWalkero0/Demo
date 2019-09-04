using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertDateTimeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = DateTime.Now.ToString();
            Console.WriteLine(Convert.ToDateTime(str).ToString("yyyy-MM-- dd HH:mm:ss"));
            str = "";
            Console.WriteLine(Convert.ToDateTime(str).ToString("yyyy-MM-- dd HH:mm:ss"));
            str = string.Empty;
            Console.WriteLine(Convert.ToDateTime(str).ToString("yyyy-MM-- dd HH:mm:ss"));
            Console.ReadKey();
        }
    }
}
