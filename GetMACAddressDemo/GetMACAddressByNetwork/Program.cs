using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics;

namespace GetMACAddressByNetwork
{
    class Program
    {
        private static Stopwatch timespan = new Stopwatch();
        static void Main(string[] args)
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                sMacAddress = adapter.GetPhysicalAddress().ToString();
                Console.WriteLine(InsertChar(sMacAddress));
            }
            Console.ReadKey();
        }

        static string InsertChar(string str)
        {
            timespan.Restart();
            StringBuilder sb = new StringBuilder();
            List<string> strs = new List<string>();
            for (int i = 0; i < str.Length / 2; i++)
            {
                strs.Add(str.Substring(i * 2, 2));
            }
            foreach(string s in strs)
            {
                sb.Append(s).Append(":");
            }
            //sb.Remove(sb.Length - 1, 1);
            //timespan.Stop();
            //sb.Append("--" + timespan.Elapsed.TotalMilliseconds);
            return sb.ToString().TrimEnd(':');
        }
    }
}
