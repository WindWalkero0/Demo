using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteSample
{
    public delegate T Calculator<T>(T arg);

    delegate void StringAction(string str);
    class Program
    {
        static int Double(int x) { return x * 2; }

        static void Main(string[] args)
        {
            int[] values = { 1, 2, 3, 4 };
            Utility.Calculator(values, Double);

            foreach(int i in values)
            {
                Console.Write(i + " ");
            }
            StringAction ac = new StringAction(ActOnObject);
            ac("Hello");
            Console.ReadKey();
        }

        static void ActOnObject(object o)
        {
            Console.WriteLine(o);
        }
    }

    class Utility
    {
        public static void Calculator<T>(T[] values, Calculator<T> c)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = c(values[i]);
            }
        }
    }
}
