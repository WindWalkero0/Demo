using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using ShanDongPig.Common;
using ShanDongPig.Entities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FluentScheduler;
using System.Media;
using System.Windows.Forms;

namespace ShanDongPig.UI
{
    public partial class MainUI : XtraForm
    {
        //界面
        private FormIndex mFormIndex = null;
        private FormSlaughter mFormSlaughter = null;
        private FormSegmentation mFormSegmentation = null;
        private FormSetting mFormSetting = null;
        private List<XtraForm> formList = new List<XtraForm>();
        //语音
        SoundPlayer errorPlayer;

        public MainUI()
        {
            InitializeComponent();

            //批次信息
            BatchDB.CreateDB();
            //统计信息
            StatisticsDB.CreateDB();

            CommonHelp.InitDBTable();
        }

        /// <summary>
        /// 添加显示界面
        /// </summary>
        private void ShowUI()
        {
            Size size = MainPanel.Size;
            Point location = new Point(0, 0);

            mFormIndex = new FormIndex();
            mFormSlaughter = new FormSlaughter();
            mFormSegmentation = new FormSegmentation();
            mFormSetting = new FormSetting();

            formList.Add(mFormIndex);
            formList.Add(mFormSlaughter);
            formList.Add(mFormSegmentation);
            formList.Add(mFormSetting);

            foreach (XtraForm form in formList)
            {
                form.Size = size;
                form.Location = location;
                form.TopLevel = false;
                MainPanel.Controls.Add(form);
            }
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            ShowUI();
            try
            {
                errorPlayer = new System.Media.SoundPlayer(Application.StartupPath + @"/语音文件/error.WAV");
            }
            catch (Exception ex)
            {

            }
            JobManager.Initialize(TimedForData.RunTask(delegate () { SyncStatisticalData(); }, TimedTaskType.Seconds, 10, true));
            JobManager.Initialize(TimedForData.RunTask(delegate () { SyncBatchInfo(); }, TimedTaskType.Days, 1, true));
            //SyncStatisticalData();
            //SyncBatchInfo();

            ShowPanel(mFormIndex);
        }

        #region 声音播放
        /// <summary>
        /// 异常语音
        /// </summary>
        private void ErrorPlay()
        {
            try
            {
                errorPlayer.Play();
            }
            catch(Exception ex)
            { }
        }
        #endregion

        /// <summary>
        /// 显示指定页面
        /// </summary>
        /// <param name="formSel"></param>
        private void ShowPanel(XtraForm formSel)
        {
            foreach (XtraForm form in formList)
            {
                if (form == formSel)
                {
                    form.Show();
                }
                else
                {
                    form.Hide();
                }
            }
        }

        private void Btn_Index_Click(object sender, EventArgs e)
        {
            ShowPanel(mFormIndex);
        }

        private void Btn_Slaughter_Click(object sender, EventArgs e)
        {
            ShowPanel(mFormSlaughter);
        }

        private void Btn_Segmentation_Click(object sender, EventArgs e)
        {
            ShowPanel(mFormSegmentation);
        }

        private void Btn_Setting_Click(object sender, EventArgs e)
        {
            ShowPanel(mFormSetting);
        }

        private void MainPanel_SizeChanged(object sender, EventArgs e)
        {
            Size size = MainPanel.Size;
            Point location = new Point(0, 0);
            foreach (XtraForm form in formList)
            {
                form.Size = size;
                form.Location = location;
            }
        }

        private void MainUI_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            try
            {
                Environment.Exit(1);
            }
            catch { }
        }

        /// <summary>
        /// 同步批次信息
        /// </summary>
        private void SyncBatchInfo()
        {
            try
            {
                string sql = string.Empty;
                ResultEntity response = HttpUtil.HttpGet(GeneralData.ServiceUrl + "production-line/batchInfo");
                if (response.State != 200)
                { }
                else
                {
                    JArray nodeList = (JArray)response.Results;
                    if (nodeList.Count != 0)
                    {
                        bool isInsert = false;//判断表中是否存在数据
                        string iCount = BatchDB.ExecuteScalar($"SELECT Count(*) FROM BatchInfo").ToString();
                        if (int.Parse(iCount) > 0)
                            isInsert = false;
                        else
                            isInsert = true;

                        int iNumber = 0;
                        List<string> batchList = new List<string>();//存储已有批次，判断发送来的数据是否有重复的
                        string sqlBatchAll = string.Empty;
                        StringBuilder sInsertBatch = new StringBuilder();

                        foreach (JObject node in nodeList)
                        {
                            string inBatch = node["inBatch"].ToString();
                            if (batchList.Contains(inBatch))
                                continue;
                            if (node["identityNums"].Count() != 0)
                            {
                                if (!isInsert) //如果有数据，先校验是否存在需要更新的，不然就是直接插入数据
                                {
                                    int isExist = Convert.ToInt32(BatchDB.ExecuteScalar($"Select Count(1) from BatchInfo where ButcherBatch = '{inBatch}'"));
                                    if (isExist >= 1)
                                    {
                                        sql = $"DELETE FROM BatchInfo WHERE ButcherBatch = '{inBatch}'";
                                        BatchDB.ExecuteNonQuery(sql);
                                    }
                                }
                                foreach (string identityNum in node["identityNums"])
                                {
                                    if (0 == iNumber)
                                    {
                                        sqlBatchAll = $"INSERT INTO BatchInfo VALUES('{inBatch}', '{identityNum}')";
                                        sInsertBatch.Append(sqlBatchAll);
                                        iNumber++;
                                    }
                                    else
                                    {
                                        sqlBatchAll = $", ('{inBatch}', '{identityNum}')";
                                        sInsertBatch.Append(sqlBatchAll);
                                        iNumber++;
                                    }
                                    if (iNumber >= 500)
                                    {
                                        BatchDB.ExecuteNonQuery(sInsertBatch.ToString());
                                        iNumber = 0;
                                        sInsertBatch.Clear();
                                    }
                                }
                            }
                            else
                                continue;
                            batchList.Add(inBatch);
                            if (iNumber >= 500)
                            {
                                BatchDB.ExecuteNonQuery(sInsertBatch.ToString());
                                iNumber = 0;
                                sInsertBatch.Clear();
                            }
                        }
                        if (iNumber != 0)
                        {
                            BatchDB.ExecuteNonQuery(sInsertBatch.ToString());
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        
        /// <summary>
        /// 同步统计信息
        /// </summary>
        private void SyncStatisticalData()
        {
            ResultEntity response = HttpUtil.HttpGet(GeneralData.ServiceUrl + "production-line/statistics");
            if (response.State != 200)
            { }
            else
            {
                JObject nodeList = JObject.Parse(response.Results.ToString());
                
                if (nodeList.Count != 0)
                {
                    string waitForButcher = nodeList["waitingButcherCount"].ToString();
                    string entryFactoryCount = nodeList["inFactoryCount"].ToString();
                    string butcherCount = nodeList["butcherCount"].ToString();
                    string packageWeight = nodeList["packageWeight"].ToString();

                    waitForButcher = string.IsNullOrWhiteSpace(waitForButcher) ? "0" : waitForButcher;
                    entryFactoryCount = string.IsNullOrWhiteSpace(entryFactoryCount) ? "0" : entryFactoryCount;
                    butcherCount = string.IsNullOrWhiteSpace(butcherCount) ? "0" : butcherCount;
                    packageWeight = string.IsNullOrWhiteSpace(packageWeight) ? "0" : packageWeight;

                    this.Invoke((EventHandler)delegate
                    {
                        mFormIndex.lbWaitForButcher.Text = waitForButcher + " 头";
                        mFormIndex.lbInFactory.Text = entryFactoryCount + " 头";
                        mFormIndex.lbButcher.Text = butcherCount + " 头";
                        mFormIndex.lbPackage.Text = packageWeight + " 公斤";
                    });
                }
            }
        }
    }
}