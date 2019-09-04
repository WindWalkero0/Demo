using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //关闭对非文本框的非线程操作检查
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }
        string RemoteEndPoint = string.Empty;//客户端的网络节点

        Thread threadWatch = null;//负责监听客户端的线程
        Socket socketWatch = null;//负责监听客户端的套接字
        //创建一个和客户但通信的套接字
        Dictionary<string, Socket> dic = new Dictionary<string, Socket> { };//定义一个集合，存储客户端信息
        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text.Trim()) || string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                MessageBox.Show("监听IP、端口号不能为空！");
                return;
            }
            //实例化一个套接字用于监听客户端发来的消息，包含三个参数（IP4寻址协议，流式连接， Tcp协议）
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //服务端连接需要IP和端口
            IPAddress address = IPAddress.Parse(textBox1.Text.Trim());//获取文本框的IP地址

            //将IP地址和端口号绑定到网络节点上
            IPEndPoint point = new IPEndPoint(address, int.Parse(textBox2.Text.Trim()));//获取文本框中的端口号
                                                                                        //此端口号专门用来监听

            //监听绑定的网络节点
            socketWatch.Bind(point);

            //将套接字的监听队列长度限制为20
            socketWatch.Listen(20);

            //实例化一个监听线程
            threadWatch = new Thread(WatchConnecting);
            threadWatch.IsBackground = true;
            threadWatch.Start();

            listBox1.Items.Add("开始监听客户端信息!");
            this.button1.Enabled = false;
        }

        void OnLineList_Disp(string strInfo)
        {
            listBox2.Items.Add(strInfo);//在线列表中显示连接的客户端套接字
        }

        private void WatchConnecting()
        {
            Socket conn = null;
            while (true)
            {
                try
                {
                    conn = socketWatch.Accept();
                }
                catch (Exception e)
                {
                    MessageBox.Show("警告", e.Message);
                    listBox1.Items.Add(e.Message);
                    break;
                }
                //获取客户端的IP和端口号
                IPAddress clientIP = (conn.RemoteEndPoint as IPEndPoint).Address;
                int clientPort = (conn.RemoteEndPoint as IPEndPoint).Port;

                //让客户端显示“连接成功”的信息
                string sendMsg = "连接服务端成功!\r\n" + "本地IP:" + clientIP + ",本地端口号：" + clientPort.ToString();
                byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendMsg);
                conn.Send(arrSendMsg);

                RemoteEndPoint = conn.RemoteEndPoint.ToString();//客户端网络节点号
                listBox1.Items.Add("成功与" + RemoteEndPoint + "客户端建立连接！");//显示与客户端连接情况
                dic.Add(RemoteEndPoint, conn);//添加客户端信息

                OnLineList_Disp(RemoteEndPoint);//显示在线客户端

                IPEndPoint netPoint = conn.RemoteEndPoint as IPEndPoint;

                //创建一个通信线程
                ParameterizedThreadStart pts = new ParameterizedThreadStart(Recv);
                Thread thread = new Thread(pts);
                thread.IsBackground = true;
                thread.Start(conn);
            }
        }

        private void Recv(object socketClientParm)
        {
            Socket socketServer = socketClientParm as Socket;
            while (true)
            {
                //创建一个内存缓冲区，其大小为1024*1024字节，即1M
                byte[] arrServerRcvMsg = new byte[1024 * 1024];

                //将接收到的信息存储到缓冲区，并返回其字节数组长度
                try
                {
                    int length = socketServer.Receive(arrServerRcvMsg);

                    string str_RecMsg = Encoding.UTF8.GetString(arrServerRcvMsg);

                    listBox1.Items.Add("客户端：" + socketServer.RemoteEndPoint + "time:" + GetCurrentTime());
                    listBox1.Items.Add(str_RecMsg);
                }
                catch (Exception e)
                {
                    listBox1.Items.Add("客户端" + socketServer.RemoteEndPoint + "已经断开连接！");//提示套接字监听异常
                    listBox2.Items.Remove(socketServer.RemoteEndPoint.ToString());
                    socketServer.Close();
                    button1.Enabled = true;
                    break;
                }
            }
        }

        private DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sendStr = textBox3.Text.Trim();

            byte[] bytes = Encoding.UTF8.GetBytes(sendStr);

            if (listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("请选择要发送的客户端！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                string selectClient = listBox2.Text;//选择要发送的客户端
                dic[selectClient].Send(bytes);
                textBox3.Clear();
                listBox1.Items.Add("服务器:" + GetCurrentTime());
                listBox1.Items.Add(sendStr);
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
            {
                e.Cancel = true;
            }
        }
    }
}
