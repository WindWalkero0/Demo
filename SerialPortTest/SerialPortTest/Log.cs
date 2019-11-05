using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SerialPortTest
{
    public class Log
    {
        public static string LogPath = System.Environment.CurrentDirectory + "\\日志\\";

        public static void Write(string message)
        {
            try
            {
                if (!Directory.Exists(LogPath + DateTime.Now.ToString("yyyyMMdd")))
                {
                    Directory.CreateDirectory(LogPath + DateTime.Now.ToString("yyyyMMdd"));
                }
                using (StreamWriter writer = new StreamWriter($"{LogPath}{DateTime.Now.ToString("yyyyMMdd")}//log.txt", true, System.Text.Encoding.Default, 0x400))
                {
                    writer.WriteLine(DateTime.Now.ToString() + "  ---  " + message);
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }
            }
            catch (Exception ex)
            {
                Message.Warning(ex.Message);
            }
        }

        public static void WritePrintCaseBox(string message)
        {
            try
            {
                if (!Directory.Exists(LogPath + DateTime.Now.ToString("yyyyMMdd")))
                {
                    Directory.CreateDirectory(LogPath + DateTime.Now.ToString("yyyyMMdd"));
                }
                using (StreamWriter writer = new StreamWriter($"{LogPath}{DateTime.Now.ToString("yyyyMMdd")}//单标打印.txt", true, System.Text.Encoding.Default, 0x400))
                {
                    writer.WriteLine(DateTime.Now.ToString() + "  ---  " + message);
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }
            }
            catch (Exception ex)
            {
                Message.Warning(ex.Message);
            }
        }

        /// <summary>
        /// 操作本地数据库异常日志
        /// </summary>
        /// <param name="message"></param>
        public static void WriteDBException(string message)
        {
            try
            {
                if (!Directory.Exists(LogPath + DateTime.Now.ToString("yyyyMMdd")))
                {
                    Directory.CreateDirectory(LogPath + DateTime.Now.ToString("yyyyMMdd"));
                }
                using (StreamWriter writer = new StreamWriter($"{LogPath}{DateTime.Now.ToString("yyyyMMdd")}//操作本地DB异常.txt", true, System.Text.Encoding.Default, 0x400))
                {
                    writer.WriteLine(DateTime.Now.ToString() + "  ---  " + message);
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }
            }
            catch (Exception ex)
            {
                Message.Warning(ex.Message);
            }
        }

        /// <summary>
        /// 指定文件名记录日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="txtName"></param>
        public static void WriteHttpPost(string message,string txtName)
        {
            try
            {
                if (!Directory.Exists(LogPath + DateTime.Now.ToString("yyyyMMdd")))
                {
                    Directory.CreateDirectory(LogPath + DateTime.Now.ToString("yyyyMMdd"));
                }
                using (StreamWriter writer = new StreamWriter($"{LogPath}{DateTime.Now.ToString("yyyyMMdd")}//{txtName}.txt", true, System.Text.Encoding.Default, 0x400))
                {
                    writer.WriteLine(DateTime.Now.ToString() + "  ---  " + message);
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }
            }
            catch (Exception ex)
            {
                Message.Warning(ex.Message);
            }
        }

        public static void WriteLaser(string message,string txtName)
        {
            try
            {
                if (!Directory.Exists(LogPath + DateTime.Now.ToString("yyyyMMdd")))
                {
                    Directory.CreateDirectory(LogPath + DateTime.Now.ToString("yyyyMMdd"));
                }
                using (StreamWriter writer = new StreamWriter($"{LogPath}{DateTime.Now.ToString("yyyyMMdd")}//{txtName}.txt", true, System.Text.Encoding.Default, 0x400))
                {
                    writer.WriteLine(DateTime.Now.ToString() + "  ---  " + message);
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }
            }
            catch (Exception ex)
            {
                Message.Warning(ex.Message);
            }
        }
    }
}
