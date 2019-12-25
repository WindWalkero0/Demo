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

        public FormSlaughter()
        {
            InitializeComponent();

            dt.Columns.Add("序号", typeof(int));
            dt.Columns.Add("进场批次", typeof(string));
            dt.Columns.Add("耳标号", typeof(string));
            dt.Columns.Add("扎带码", typeof(string));
            dt.Columns.Add("扎带码来源", typeof(string));
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
            for (int i = 1; i <= 100; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        DealSlaughter("");
                        break;
                    case 1:
                        DealDehead("");
                        break;
                    case 2:
                        DealRemoveAcid("");
                        break;
                }
            }
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
            dr[4] = OperateType.屠宰.ToString();
            dr[5] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dr[8] = "待上传";
            SlaughterEntity slaughter = new SlaughterEntity
            {
                butcherBatch = dr[1].ToString(),
                identityNum = dr[2].ToString(),
                ribbonCode = dr[3].ToString(),
                excuteTime = dr[5].ToString(),
                excuteType = (int)OperateType.屠宰
            };
            displayQueue.Enqueue(dr);
            slaughterQueue.Enqueue(slaughter);
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
            dr[4] = OperateType.去头.ToString();
            dr[6] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dr[8] = "待上传";
            SlaughterEntity slaughter = new SlaughterEntity
            {
                butcherBatch = dr[1].ToString(),
                identityNum = dr[2].ToString(),
                ribbonCode = dr[3].ToString(),
                excuteTime = dr[6].ToString(),
                excuteType = (int)OperateType.去头
            };
            displayQueue.Enqueue(dr);
            slaughterQueue.Enqueue(slaughter);
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
            dr[4] = OperateType.排酸.ToString();
            dr[7] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dr[8] = "待上传";
            SlaughterEntity slaughter = new SlaughterEntity
            {
                butcherBatch = dr[1].ToString(),
                identityNum = dr[2].ToString(),
                ribbonCode = dr[3].ToString(),
                excuteTime = dr[7].ToString(),
                excuteType = (int)OperateType.排酸
            };
            displayQueue.Enqueue(dr);
            slaughterQueue.Enqueue(slaughter);
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
            if (tUploadData == null)
            {
                tUploadData = new JGWThread(UploadData);
                tUploadData.Run();
                tUploadData.thread.Priority = ThreadPriority.Lowest;
            }
        }

        void UploadData()
        {
            while (!tUploadData.CloseFlag)
            {
                try
                {
                    if (!slaughterQueue.IsEmpty)
                    {
                        if (slaughterQueue.TryDequeue(out SlaughterEntity slaughterEntity))
                        {
                            ResultType result = InterfaceServices.UploadSlaughterInfo(slaughterEntity, out string error);
                            DataRow[] dr;
                            do
                            {
                                dr = dt.Select($"进场批次 = '{slaughterEntity.butcherBatch}' " +
                                      $"and 扎带码来源 = '{Enum.GetName(typeof(OperateType), slaughterEntity.excuteType)}' " +
                                      $"and 扎带码 = '{slaughterEntity.ribbonCode}'", "序号 DESC");
                            } while (dr.Count() == 0);
                            this.Invoke((EventHandler)delegate
                                {
                                    dr[0]["上传结果"] = result;
                                });
                            //DataRow[] dr = dt.Select($"进场批次 = '{slaughterEntity.butcherBatch}' " +
                            //        $"and 扎带码来源 = '{Enum.GetName(typeof(OperateType), slaughterEntity.excuteType)}' " +
                            //        $"and 扎带码 = '{slaughterEntity.ribbonCode}'", "序号 DESC");
                            //if(dr.Count() != 0)
                            //{
                            //    this.Invoke((EventHandler)delegate
                            //    {
                            //        dr[0]["上传结果"] = result;
                            //    });
                            //}
                        }
                    }
                    Thread.Sleep(1);
                }
                catch (Exception ex) { }
            }
        }
        #endregion
    }
}