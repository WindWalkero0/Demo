using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System.Threading;
using System.Collections.Concurrent;
using ShanDongPig.Entities;
using ShanDongPig.Common;
using System.Diagnostics;

namespace ShanDongPig.UI
{
    public partial class FormSlaughter : XtraForm
    {
        /// <summary>
        /// 屠宰上传数据队列
        /// </summary>
        ConcurrentQueue<SlaughterEntity> slaughterQueue = new ConcurrentQueue<SlaughterEntity>();
        /// <summary>
        /// 不同识读器显示数据队列
        /// </summary>
        ConcurrentQueue<DataRow> displayQueue = new ConcurrentQueue<DataRow>();
        DataTable dt = new DataTable("屠宰");
        Stopwatch stop = new Stopwatch();

        Thread th = null;
        public FormSlaughter()
        {
            InitializeComponent();
            
            dt.Columns.Add("序号", typeof(int));
            dt.Columns.Add("进场批次", typeof(string));
            dt.Columns.Add("耳标号", typeof(string));
            dt.Columns.Add("扎带码", typeof(string));
            dt.Columns.Add("扎带码来源", typeof(int));
            dt.Columns.Add("屠宰时间", typeof(string));
            dt.Columns.Add("去头时间", typeof(string));
            dt.Columns.Add("排酸时间", typeof(string));
            dt.Columns.Add("上传结果", typeof(string));


            this.GridControl_Slaughter.DataSource = dt;
        }

        private void FormSlaughter_Load(object sender, EventArgs e)
        {
            StartDisplay();
            StartUpload();
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            stop.Restart();
            DealSlaughter("");
        }
        /// <summary>
        /// 屠宰
        /// </summary>
        /// <param name="data"></param>
        private void DealSlaughter(string data)
        {
            DataRow dr = dt.NewRow();
            dr[1] = "123456";
            dr[2] = "2";
            dr[3] = "东西";
            dr[4] = OperateType.屠宰;
            dr[5] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SlaughterEntity slaughter = new SlaughterEntity
            {
                butcherBatch = dr[1].ToString(),
                identityNum = dr[2].ToString(),
                ribbonCode = dr[3].ToString(),
                excuteTime = dr[5].ToString(),
                excuteType = Convert.ToInt32(dr[4])
            };
            slaughterQueue.Enqueue(slaughter);
            displayQueue.Enqueue(dr);
        }
        /// <summary>
        /// 去头
        /// </summary>
        /// <param name="data"></param>
        private void DealDehead(string data)
        {
            DataRow dr = dt.NewRow();
            dr[1] = "张三";
            dr[2] = "2";
            dr[3] = "东西";
            dr[4] = OperateType.去头;
            dr[6] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SlaughterEntity slaughter = new SlaughterEntity
            {
                butcherBatch = dr[1].ToString(),
                ribbonCode = dr[3].ToString(),
                excuteTime = dr[6].ToString(),
                excuteType = Convert.ToInt32(dr[4])
            };
            slaughterQueue.Enqueue(slaughter);
            displayQueue.Enqueue(dr);
        }
        /// <summary>
        /// 排酸
        /// </summary>
        /// <param name="data"></param>
        private void DealRemoveAcid(string data)
        {
            DataRow dr = dt.NewRow();
            dr[1] = "张三";
            dr[2] = "2";
            dr[3] = "东西";
            dr[4] = OperateType.排酸;
            dr[7] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SlaughterEntity slaughter = new SlaughterEntity
            {
                butcherBatch = dr[1].ToString(),
                ribbonCode = dr[3].ToString(),
                excuteTime = dr[7].ToString(),
                excuteType = Convert.ToInt32(dr[4])
            };
            slaughterQueue.Enqueue(slaughter);
            displayQueue.Enqueue(dr);
        }

        #region 动态显示数据
        JGWThread tDisplayData = null;

        private void StartDisplay()
        {
            if (tDisplayData == null)
            {
                tDisplayData = new JGWThread(DisplayData);
                tDisplayData.Run();
                tDisplayData.thread.Priority = ThreadPriority.Lowest;
            }
        }

        void DisplayData()
        {
            while (!tDisplayData.CloseFlag)
            {
                try
                {
                    if (!displayQueue.IsEmpty)
                    {
                        if (displayQueue.TryDequeue(out DataRow dr))
                        {
                            dr[0] = dt.Rows.Count + 1;
                            this.Invoke((EventHandler)delegate
                            {
                                dt.Rows.InsertAt(dr, 0);
                                this.GridView_Slaughter.FocusedRowHandle = 0;
                                this.GridView_Slaughter.PopulateColumns();//显示GridControl的数据
                            });
                            stop.Stop();
                            Log.WriteHttpPost(stop.ElapsedMilliseconds.ToString(), "运行时间");
                        }
                    }
                    Thread.Sleep(1);
                }
                catch (Exception ex) { Thread.Sleep(1); }
            }
        }
        #endregion

        #region 屠宰数据上传
        JGWThread tUploadData = null;

        private void StartUpload()
        {
            if(tUploadData == null)
            {
                tUploadData = new JGWThread(UploadData);
                tUploadData.Run();
                tUploadData.thread.Priority = ThreadPriority.Lowest;
            }
        }

        void UploadData()
        {
            while(!tUploadData.CloseFlag)
            {
                try
                {
                    if (!slaughterQueue.IsEmpty)
                    {
                        if (slaughterQueue.TryDequeue(out SlaughterEntity slaughterEntity))
                        {
                            ResultType result = InterfaceServices.UploadSlaughterInfo(slaughterEntity, out string error);
                        }
                    }
                }
                catch(Exception ex) { }
            }
        }
        #endregion
    }
}