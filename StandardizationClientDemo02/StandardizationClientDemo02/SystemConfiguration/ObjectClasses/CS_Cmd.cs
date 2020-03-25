using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace StandardizationClientDemo02.SystemConfiguration.ObjectClasses
{
    public class CS_Cmd
    {
        /// <summary>
        /// 执行Cmd命令
        /// </summary>
        /// <param name="workingDirectory">要启动的进程目录</param>
        /// <param name="command">要执行的命令</param>
        public static void StartCmd(String workingDirectory, String command)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = workingDirectory;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(command);
            p.StandardInput.WriteLine("Exit");
        }
    }
}
