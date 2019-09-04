using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadLeftOrRightDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    string str = "gdsafs";
                    Console.WriteLine(int.Parse(str));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("能继续走");
            Console.Read();
        }
    }
}
