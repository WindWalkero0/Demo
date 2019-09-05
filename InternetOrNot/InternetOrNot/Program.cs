/*
通过调用系统自带dll检测是否联网 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace InternetOrNot
{
    class Program
    {
        /// <summary>
        /// 获取电脑联网状态，true为联网，false为断网
        /// </summary>
        /// <param name="conState"></param>
        /// <param name="reder"></param>
        /// <returns></returns>
        [DllImport("wininet")]
        public extern static bool InternetGetConnectedState(out int conState, int reder);
        static void Main(string[] args)
        {
            int i = 0;
            if (InternetGetConnectedState(out i, 0))
            {
                Console.WriteLine("设备联网正常！");
            }
            else
            {
                Console.WriteLine("设备已断网！");
            }
            Console.ReadKey();
        }
    }
}
