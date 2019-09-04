using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertChar
{
    class Program
    {
        static void Main(string[] args)
        {
            string str_Char = "  KTEEEEEEESAFDSAFGSFDS";
            //if (str_Char.Contains("("))
            //{
            //    str_Char = str_Char.Insert(str_Char.IndexOf("("), "\r\n");
            //}

            str_Char = str_Char.Replace("\r", string.Empty);
            Console.WriteLine(str_Char.Length);
            Console.WriteLine(str_Char.IndexOf("eee"));
            Console.ReadKey();
        }
    }
}
