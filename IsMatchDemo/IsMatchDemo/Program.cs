using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IsMatchDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "D4329052FDSAF";
            Regex regex = new Regex("[ABC]");
            Match m = regex.Match(str.Substring(0, 1));
            if (m.Success)
                Console.WriteLine("匹配成功");
            else
                Console.WriteLine("匹配失败");
            Console.ReadKey();
        }
    }
}
