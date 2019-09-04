using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> que = new Queue<string>();
            for (int i = 0; i < 1000; i++)
            {
                que.Enqueue(i.ToString());
            }
            Console.WriteLine(que.Count);
            for(int i = 0; i < 1000; i++)
            {
                Console.WriteLine(que.Dequeue());
            }
            Console.ReadKey();
        }
    }
}
