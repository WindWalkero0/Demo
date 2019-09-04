using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using AForge;
using AForge.Video;
using AForge.Controls;
using AForge.Video.DirectShow;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
    //***************************************************
    //    一个简单的调用电脑摄像头Demo
    //***************************************************
namespace WindowsCameraDemo
{
    public partial class VideoDisplay : Form
    {
        //private int hHwnd;
        public FilterInfoCollection videoCollection;
        public VideoDisplay()
        {
            InitializeComponent();
        }
        #region**************************Can`t display the video
        //public struct Videohdr_tag
        //{
        //    public byte[] lpData;
        //    public int dwBufferLength;
        //    public int dwBytesUsed;
        //    public int dwTimeCaptured;
        //    public int iUser;
        //    public int iFlags;
        //    public int[] dwReserved;
        //}

        //#region P/Invoke
        //[DllImport("avicap32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        //public static extern int capCreateCaptureWindowA([MarshalAs(UnmanagedType.VBByRefStr)]   ref string lpszWindowName, int dwStyle, int x, int y, int nWidth, short nHeight, int hWndParent, int nID);
        //[DllImport("avicap32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        //public static extern bool capGetDriverDescriptionA(short wDriver, [MarshalAs(UnmanagedType.VBByRefStr)]   ref string lpszName, int cbName, [MarshalAs(UnmanagedType.VBByRefStr)]   ref string lpszVer, int cbVer);
        //[DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        //public static extern bool DestroyWindow(int hndw);
        //[DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        //public static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)]   object lParam);
        //[DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        //public static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        //[DllImport("vfw32.dll")]
        //public static extern string capVideoStreamCallback(int hwnd, Videohdr_tag videohdr_tag);
        //[DllImport("vicap32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        //public static extern bool capSetCallbackOnFrame(int hwnd, string s);
        //#endregion

        ///// <summary>
        ///// Initialize Video and display the video in a panel.
        ///// </summary>
        ///// <returns></returns>
        //private bool InitializeWebCam()
        //{
        //    bool ok = false;

        //    int intWidth = this.panel1.Width;
        //    int intHeight = this.panel1.Height;
        //    int intDevice = 0;
        //    string refDevice = intDevice.ToString();

        //    //Create vedio and get the window handle.
        //    hHwnd = capCreateCaptureWindowA(ref refDevice, 1342177280, 0, 0, 640, 480, this.panel1.Handle.ToInt32(), 0);

        //    if (VideoDisplay.SendMessage(hHwnd, 0x40a, intDevice, 0) > 0)
        //    {
        //        VideoDisplay.SendMessage(this.hHwnd, 0x435, -1, 0);
        //        VideoDisplay.SendMessage(this.hHwnd, 0x434, 0x42, 0);
        //        VideoDisplay.SendMessage(this.hHwnd, 0x432, -1, 0);
        //        VideoDisplay.SetWindowPos(this.hHwnd, 1, 0, 0, intWidth, intHeight, 6);

        //        ok = true;
        //    }
        //    else
        //    {
        //        VideoDisplay.DestroyWindow(this.hHwnd);
        //    }

        //    return ok;
        //}

        //private void VideoDisplay_Load(object sender, EventArgs e)
        //{
        //    bool ok = false;

        //    while(!ok)
        //    {
        //        ok = this.InitializeWebCam();
        //        System.Threading.Thread.Sleep(200);
        //    }
        //}

        //public void CloseVideoCap()
        //{
        //    if (hHwnd > 0)
        //    {
        //        VideoDisplay.SendMessage(this.hHwnd, 0x40b, 0, 0);
        //        VideoDisplay.DestroyWindow(this.hHwnd);
        //    }
        //}
        //private void VideoDisplay_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    CloseVideoCap();
        //}

        //private void VideoDisplay_SizeChanged(object sender, EventArgs e)
        //{
        //    VideoDisplay.SetWindowPos(this.hHwnd, 1, 0, 0, this.Width, this.Height, 6);
        //}
        #endregion

        private void VideoDisplay_Load(object sender, EventArgs e)
        {
            try
            {
                videoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoCollection.Count == 0)
                    throw new ApplicationException();

                foreach (FilterInfo device in videoCollection)
                {
                    comboBox1.Items.Add(device.Name);
                }

               // comboBox1.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                comboBox1.Items.Add("未发现摄像头");
                comboBox1.SelectedIndex = 0;
                videoCollection = null;
            }
        }
        /// <summary>
        /// 连接摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            button2_Click(null, null);
            if(comboBox1.SelectedItem.ToString() == "未发现摄像头")
            {
                MessageBox.Show("未发现摄像头！", "错误提示",MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoCollection[comboBox1.SelectedIndex].MonikerString);
            videoSource.VideoResolution = videoSource.VideoCapabilities[comboBox2.SelectedIndex];

            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();
        }
        /// <summary>
        /// 关闭摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if(videoSourcePlayer1 != null && videoSourcePlayer1.IsRunning)
            {
                videoSourcePlayer1.SignalToStop();
                videoSourcePlayer1.WaitForStop();
            }
        }
        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(videoSourcePlayer1.IsRunning)
                {
                    BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                        videoSourcePlayer1.GetCurrentVideoFrame().GetHbitmap(),
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
                    PngBitmapEncoder pE = new PngBitmapEncoder();
                    pE.Frames.Add(BitmapFrame.Create(bitmapSource));
                    string picName = GetImagePath() + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                    if (File.Exists(picName))
                    {
                        File.Delete(picName);
                    }
                    using (Stream stream = File.Create(picName))
                    {
                        pE.Save(stream);
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        /// <summary>
        /// 获取图片路径
        /// </summary>
        /// <returns></returns>
        private string GetImagePath()
        {
            string personImgPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "Img";
            if(!Directory.Exists(personImgPath))
            {
                Directory.CreateDirectory(personImgPath);
            }

            return personImgPath;
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            button2_Click(null, null);
        }
        /// <summary>
        /// 更改摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "未发现摄像头")
            {
                comboBox2.Items.Add("未发现摄像头");
                comboBox2.SelectedIndex = 0;
                return;
            }
            VideoCaptureDevice videoCaptureDevice = new VideoCaptureDevice(videoCollection[comboBox1.SelectedIndex].MonikerString);
            if(0 == videoCaptureDevice.VideoCapabilities.Count())
            {
                comboBox2.Items.Add("摄像头异常");
                comboBox2.SelectedIndex = 0;
                return;
            }
            comboBox2.Items.Clear();
            foreach (VideoCapabilities fbl in videoCaptureDevice.VideoCapabilities)
            {
                comboBox2.Items.Add(fbl.FrameSize.Width + "*" + fbl.FrameSize.Height);
            }
            comboBox2.SelectedIndex = 0;
            button1_Click(null, null);
        }
        /// <summary>
        /// 更改分辨率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedItem.ToString() == "未发现摄像头" ||
                comboBox2.SelectedItem.ToString() == "摄像头异常")
            {
                button1_Click(null, null);
            }
        }
    }
}
