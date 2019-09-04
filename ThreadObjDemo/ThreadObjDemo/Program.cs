using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadObjDemo
{
    class Program
    {
        static Thread th = null;
        static Thread th1 = null;
        static bool flag = false;
        static Queue<string> queueList01 = new Queue<string>();
        static Queue<string> queueList02 = new Queue<string>();
        static EventWaitHandle eHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
        static int i = 0;
        static void Main(string[] args)
        {
            th = new Thread(StartCount);
            th.Start();

            th1 = new Thread(Control);
            th1.Start();
        }

        static void StartCount()
        {
            string str = "常驻成员";
            //while (!flag)
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine(str + i);
            //        Thread.Sleep(500);
            //    }
            //    eHandle.WaitOne();
            //    for (int i = 50; i < 60; i++)
            //    {
            //        Console.WriteLine(str + i);
            //        Thread.Sleep(500);
            //    }
            //    eHandle.Reset();
            //    Console.WriteLine("可怕");
            //}
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(800);
                queueList01.Enqueue(str + i);
            }
            Console.ReadKey();
        }

        static void Control()
        {
            while (true)
            {
                if (queueList01.Count == 0)
                {
                    Thread.Sleep(750);
                    if (queueList01.Count == 0)
                    {
                        Console.WriteLine("超时");
                    }
                    else
                        Console.WriteLine(queueList01.Dequeue());
                }
                else
                    Console.WriteLine(queueList01.Dequeue());
                Thread.Sleep(5);
            }
        }
    }
}
