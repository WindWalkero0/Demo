using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string strOne = "12345    ";
                string strTwo = "12.345";
                string strThree = "12.345      ";
                string str = "123456\n";
                bool b = true;
                char[] c = str.ToCharArray();
                Console.WriteLine(Convert.ToInt32(strOne));
                //Console.WriteLine(Convert.ToInt32(strTwo));
                //Console.WriteLine(Convert.ToInt32(strThree));
                Console.WriteLine("\r\n\r\n");
                Console.WriteLine(int.Parse(strOne));
                Console.WriteLine(b.ToString());
                Console.WriteLine(str.Length);
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
            Console.ReadKey();
        }
    }
}
