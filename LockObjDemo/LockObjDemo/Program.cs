using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LockObjDemo
{
    class Program
    {
        private static object objLock = new object();

        static void Main(string[] args)
        {
            Thread t = new Thread(StartCount);
            t.IsBackground = true;
            t.Start();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            lock(objLock)
            {
                Console.WriteLine("锁住线程5s");
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
        }

        static void StartCount()
        {
            int i = 0;
            while(true)
            {
                Console.WriteLine((i++).ToString());
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}
