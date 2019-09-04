using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace SocketClientDemo
{
    public partial class Form1 : Form
    {
        static byte[] buffer = new byte[1024];

        int iCount = 0;
        public Form1()
        {
            InitializeComponent();
            //关闭对文本框的非法线程操作检查
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        //创建一个客户端套接字、一个客户端接收服务器消息线程
        Thread threadClient = null;
        Socket socketClient = null;
        bool flag = false;
        List<IPEndPoint> mlist = new List<IPEndPoint>();
        //①创建一个Socket
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private void button1_Click(object sender, EventArgs e)
        {
            #region
            if (string.IsNullOrEmpty(textBox1.Text.Trim()) || string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                MessageBox.Show("IP地址、端口号不能为空！");
                return;
            }
            this.button1.Enabled = false;

            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress address = IPAddress.Parse(textBox1.Text.Trim());

            IPEndPoint point = new IPEndPoint(address, int.Parse(textBox2.Text.Trim()));

            try
            {
                socketClient.Connect(point);
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接异常！\r\n" + ex.Message);
                this.button1.Enabled = true;
                return;
            }

            threadClient = new Thread(Recv);
            threadClient.IsBackground = true;
            threadClient.Start();
            #endregion
            //try
            //{
            //    //②连接到指定服务器的指定端口
            //    IPAddress address = IPAddress.Parse(textBox1.Text.Trim());
            //    socket.Connect(address, Convert.ToInt32(textBox2.Text.Trim())); //localhost代表本机
            //    MessageBox.Show("连接成功");

            //    //WriteLine("client:connect to server success!", ConsoleColor.White);

            //    //③实现异步接受消息的方法 客户端不断监听消息
            //    socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(Recv), socket);

            //    //④接受用户输入，将消息发送给服务器端
            //    //while (true)
            //    //{
            //    //    var message = Console.ReadLine();
            //    //    var outputBuffer = Encoding.UTF8.GetBytes(message);
            //    //    socket.BeginSend(outputBuffer, 0, outputBuffer.Length, SocketFlags.None, null, null);
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    //WriteLine("client:error " + ex.Message, ConsoleColor.Red);
            //}
            //finally
            //{
            //    //Console.Read();
            //}
        }

        private void Recv()
        {
            #region 
            //int x = 0;
            while (true)
            {
                try
                {
                    if(flag)
                    {
                        byte[] arrRecvMsg = new byte[1024 * 1024];
                        //将客户端套接字接收到的数据存入内存缓冲区，并获取长度
                        int length = socketClient.Receive(arrRecvMsg);

                        //将套接字获取到的字符数组转换为人可以看懂的字符串
                        string strRevMsg = Encoding.UTF8.GetString(arrRecvMsg, 0, length);
                        Random rand = new Random();
                        //int i = rand.Next(1, 4);
                        //SendToServer send = (SendToServer)i;
                        //switch (strRevMsg)
                        //{
                        //    case "MarkStart\r\n":
                        //        listBox1.Items.Add("服务器:" + GetCurrentTime());
                        //        listBox1.Items.Add(strRevMsg);
                        //        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                        //        Thread.Sleep(1000);
                        //        ClientSendMsg(send.ToString());
                        //        break;
                        //    default:
                        //        listBox1.Items.Add("服务器:" + GetCurrentTime());
                        //        listBox1.Items.Add(strRevMsg);
                        //        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                        //        ClientSendMsg(strRevMsg);
                        //        break;
                        //}
                        listBox1.Items.Add($"【服务器：{GetCurrentTime()}】: {strRevMsg}");
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                        ClientSendMsg("$MarkEnd_OK\r\n");
                    }
                    Thread.Sleep(5);
                    //if (x == 1)
                    //{
                    //}
                    //else
                    //{
                    //    textBox4.Text += strRevMsg + "\r\n";
                    //    x = 1;
                    //}
                }
                catch (Exception e)
                {
                    listBox1.Items.Add("远程服务器已经中断连接!");
                    listBox1.Items.Add(e.Message);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    this.button1.Enabled = true;
                    break;
                }
            }
            #endregion
            //try
            //{
            //    var socket = ar.AsyncState as Socket;

            //    //方法参考：http://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket.endreceive.aspx
            //    var length = socket.EndReceive(ar);
            //    //读取出来消息内容
            //    var message = Encoding.ASCII.GetString(buffer, 0, length);
            //    listBox1.Items.Insert(0, message);
            //    //显示消息
            //    //WriteLine(message, ConsoleColor.White);

            //    //接收下一个消息(因为这是一个递归的调用，所以这样就可以一直接收消息了）
            //    socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(Recv), socket);
            //    string str = Encoding.UTF8.GetString(buffer);
            //    Random rand = new Random();
            //    int i = rand.Next(1, 4);
            //    SendToServer send = (SendToServer)i;
            //    switch(str)
            //    {
            //        case "MarkStart\r\n":
            //            Thread.Sleep(1000);
            //            buffer = Encoding.UTF8.GetBytes(send.ToString());
            //            socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, null, null);
            //            break;
            //        default:
            //            socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, null, null);
            //            break;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //WriteLine(ex.Message, ConsoleColor.Red);
            //}
        }

        public static void WriteLine(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("[{0}] {1}", DateTime.Now.ToString("MM-dd HH:mm:ss"), str);
        }

        public enum SendToServer
        {
            Receive_Error = 1,
            SysNoReady = 2,
            MarkStart_OK = 3,
            MarkStart_Error = 4
        }

        private DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }

        private void ClientSendMsg(string sendMsg)
        {
            try
            {
                List<byte> buffer = new List<byte>();
                byte[] b1 = { 0x02 };
                byte[] b2 = { 0x03 };
                string beginFlag = Encoding.ASCII.GetString(b1);
                string endFlag = Encoding.ASCII.GetString(b2);
                //将输入的内容字符串转换为机器可以识别的字节数组   
                byte[] arrClientSendMsg = Encoding.UTF8.GetBytes(sendMsg);

                buffer.AddRange(b1);
                buffer.AddRange(arrClientSendMsg);
                buffer.AddRange(b2);
                //调用客户端套接字发送字节数组   

                socketClient.Send(buffer.ToArray());
                //将发送的信息追加到聊天内容文本框中   
                listBox1.Items.Add("客户端:" + GetCurrentTime());
                listBox1.Items.Add(sendMsg);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            iCount = Convert.ToInt32(textBox4.Text);
            Thread th1 = new Thread(StartSend);
            th1.IsBackground = true;
            th1.Start();
        }

        void StartSend()
        {
            for (int i = 0; i < iCount; i++)
            {
                //var outputBuffer = Encoding.UTF8.GetBytes(textBox3.Text.Trim());
                //socket.BeginSend(outputBuffer, 0, outputBuffer.Length, SocketFlags.None, null, null);
                ClientSendMsg(textBox3.Text.Trim() + "\r\n");
            //listBox1.Refresh();
            Thread.Sleep(1200);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否退出？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
            else
                e.Cancel = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            socketClient.Close();
            flag = false;
        }
    }
}
