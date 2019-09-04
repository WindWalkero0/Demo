using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace GetMACAddressDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        Console.WriteLine(mo["MacAddress"].ToString());
                    }
                }
                mc = null;
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }

            Console.ReadKey();
        }
    }
}
