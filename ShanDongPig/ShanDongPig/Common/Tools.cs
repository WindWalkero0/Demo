using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors;

namespace ShanDongPig.Common
{
    public static class Tools
    {
        static ManualResetEvent m_eventAccessAvilable = new ManualResetEvent(true);
        
        #region 设置控件圆角

        /// <summary>
        /// 修改控件为圆角
        /// </summary>
        /// <param name="bt">控件</param>
        public static void SetWindowRegion(Control bt, int nRadius = 3)
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;

            FormPath = new System.Drawing.Drawing2D.GraphicsPath();

            //Rectangle rect = new Rectangle(-1, -1, this.Width + 1, this.Height);
            Rectangle rect = new Rectangle(-1, -1, bt.Width + 1, bt.Height + 1);

            FormPath = GetRoundedRectPath(rect, nRadius);

            //this.Region = new Region(FormPath);
            bt.Region = new Region(FormPath);
        }

        public static System.Drawing.Drawing2D.GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;

            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            //   左上角   
            path.AddArc(arcRect, 185, 90);

            //   右上角   
            arcRect.X = rect.Right - diameter;

            path.AddArc(arcRect, 275, 90);

            //   右下角   
            arcRect.Y = rect.Bottom - diameter;

            path.AddArc(arcRect, 5, 90);

            //   左下角   
            arcRect.X = rect.Left;

            arcRect.Width += 1;

            arcRect.Height += 1;

            path.AddArc(arcRect, 95, 90);

            path.CloseFigure();

            return path;
        }
        #endregion

        #region 选中某个按钮就显示当前按钮
        public static void DisplayButton(SimpleButton buttonClick , List<SimpleButton> listButton)
        {
            foreach (SimpleButton button in listButton)
            {
                if (button.Handle == buttonClick.Handle)
                {
                    button.Appearance.BackColor = Color.Red;
                    button.Appearance.BackColor2 = Color.Red;
                    button.BackColor = System.Drawing.Color.FromArgb(168, 255, 168);
                }
                else
                {
                    button.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }
        #endregion

        #region 注册表
        /// <summary>
        /// 写注册表值
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="value"></param>
        /// <param name="strPath"></param>
        public static void SetRegKey(string strName, object value, string strPath = "Software\\JGWClient")
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(strPath, true);
            if (null == key)
            {
                key = Registry.CurrentUser.CreateSubKey(strPath);
            }
            key.SetValue(strName, value);
            key.Close();
        }

        public static object GetRegKey(string strName, string strPath = "Software\\JGWClient")
        {
            object obValue = "";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(strPath, false);
            string[] strKeys = { };
            if (key != null)
                strKeys = key.GetValueNames();
            if (strKeys.Contains(strName))
            {
                obValue = key.GetValue(strName);
            }
            key.Close();
            return obValue;
        }

        public static string[] GetRegNames(string strPath = "Software\\JGWClient")
        {
            string[] strNames = { };
            RegistryKey keyCom = Registry.CurrentUser.OpenSubKey(strPath, false);
            if (keyCom != null)
            {
                strNames = keyCom.GetValueNames();

                keyCom.Close();
            }

            return strNames;
        }
        /// <summary>
        /// 是否存在对应键值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public static bool IsExistName(string name, string strPath = "Software\\JGWClient")
        {
            RegistryKey keys = Registry.CurrentUser.OpenSubKey(strPath, false);
            string[] strKeys = { };
            if (keys != null)
            {
                if (keys.GetValueNames().Contains(name))
                    return true;
                else
                    return false;
            }
            return false;
        }
        #endregion

        #region 获取设备上的COM
        public static string[] AvailableCOM
        {
            get
            {
                List<string> listValues = new List<string>();
                RegistryKey keyCom = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DEVICEMAP\SERIALCOMM", false);
                if (keyCom != null)
                {
                    foreach (string strName in keyCom.GetValueNames())
                    {
                        listValues.Add(keyCom.GetValue(strName).ToString());
                    }

                    keyCom.Close();
                }

                return listValues.ToArray();
            }

        }
        #endregion

        #region 设置或清除TextEdit的水印
        /// <summary>
        /// 设置水印
        /// </summary>
        /// <param name="textEdit"></param>
        /// <param name="watermark"></param>
        public static void SetWatermark(this TextEdit textEdit, string watermark)
        {
            textEdit.Properties.NullValuePromptShowForEmptyValue = true;
            textEdit.Properties.NullValuePrompt = watermark;
        }
        /// <summary>
        /// 清除水印
        /// </summary>
        /// <param name="textEdit"></param>
        public static void ClearWatermark(this TextEdit textEdit)
        {
            if (textEdit.Properties.NullValuePromptShowForEmptyValue)
                textEdit.Properties.NullValuePrompt = string.Empty;
        }
        #endregion

        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion
    }
}
