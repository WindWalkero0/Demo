using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CreateCode
{
    public partial class Form1 : Form
    {

        static SQLiteConnection conn = new SQLiteConnection(@"data source= D:\\GN_LED\\GN_LED(Scanner)\\GongNiuLaser\\bin\\Debug\\喷码数据\\TaggerCode.db;Pooling=true;FailIfMissing=false");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                Random randrom = new Random((int)DateTime.Now.Ticks);

                string str = "";
                string sql = "";
                for (int m = 0; m < 50; m++)
                {
                    int iCount = 0;
                    for (int j = 0; j < 10000; j++)
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            str += chars[randrom.Next(chars.Length)];
                        }
                        if (0 == iCount)
                        {
                            sql = string.Format(@"insert into TaggerCode(Code, UseFlag, CreateTime) values('{0}','{1}','{2}')",
                        str, "0", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            iCount++;
                        }
                        else
                        {
                            sql += string.Format(@",('{0}','{1}','{2}')",
                        str, "0", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        listBox1.Refresh();
                        listBox1.Items.Insert(0, str);

                        str = string.Empty;
                    }
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    label1.Refresh();
                    label1.Text = "已生成" + ((m+1) * 10000).ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
            }
            catch { }
        }
    }
}
