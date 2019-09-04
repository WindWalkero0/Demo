using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturnDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string s = "123...";
                Console.WriteLine(Convert.ToInt32(s));

            }
            catch(Exception ex)
            {
                throw ex;
                return;
            }
            Console.Read();
        }
    }
}
