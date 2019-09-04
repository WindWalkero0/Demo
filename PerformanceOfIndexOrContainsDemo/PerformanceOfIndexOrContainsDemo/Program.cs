using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceOfIndexOrContainsDemo
{
    class Program
    {
        static Stopwatch timeSpan = new Stopwatch();

        static void Main(string[] args)
        {
            
            string str = "fdshalkgksaghdsasbanfsadfsotewt0--43中华人民共和国24237532klfdsafdsag89532432kfds";
            int iFlag1 = 12331;
            int iFlag2 = 12332;
            string str1 = string.Empty;
            string str2 = string.Empty;
            StringBuilder sb = new StringBuilder();
            timeSpan.Reset();
            timeSpan.Restart();
            if (str.Contains("klfd"))
            { timeSpan.Stop(); Console.WriteLine(timeSpan.Elapsed.TotalMilliseconds); }
            timeSpan.Reset();
            timeSpan.Restart();
            if(str.IndexOf("klfd") >= 0)
            { timeSpan.Stop();Console.WriteLine(timeSpan.Elapsed.TotalMilliseconds); }
            //timeSpan.Reset();
            //timeSpan.Restart();
            //if (str.Contains("中华人民共和国"))
            //{ timeSpan.Stop(); Console.WriteLine(timeSpan.Elapsed.TotalMilliseconds); }
            //timeSpan.Reset();
            //timeSpan.Restart();
            //if (str.IndexOf("中华人民共和国") >= 0)
            //{ timeSpan.Stop(); Console.WriteLine(timeSpan.Elapsed.TotalMilliseconds); }
            timeSpan.Reset();
            timeSpan.Start();
            str1 = iFlag1 + "--" + iFlag2;
            timeSpan.Stop();
            Console.WriteLine(timeSpan.Elapsed.TotalMilliseconds);
            timeSpan.Reset();
            timeSpan.Restart();
            str1 = $"{iFlag1}--{iFlag2}";
            timeSpan.Stop();
            Console.WriteLine(timeSpan.Elapsed.TotalMilliseconds);
            timeSpan.Reset();
            timeSpan.Start();
            sb.Append(iFlag1).Append("--").Append(iFlag2);
            str2 = sb.ToString();
            timeSpan.Stop();
            Console.WriteLine(timeSpan.Elapsed.TotalMilliseconds);
            Console.ReadKey();
        }
    }
}
