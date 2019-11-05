namespace SerialPortTest
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gbx_Device01 = new System.Windows.Forms.GroupBox();
            this.tbxDevice01_EndFlag = new System.Windows.Forms.TextBox();
            this.tbxDevice01_BeginFlag = new System.Windows.Forms.TextBox();
            this.CbxDevice01_Baud = new System.Windows.Forms.ComboBox();
            this.CbxDevice01_COM = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbx_Device02 = new System.Windows.Forms.GroupBox();
            this.tbxDevice02_EndFlag = new System.Windows.Forms.TextBox();
            this.tbxDevice02_BeginFlag = new System.Windows.Forms.TextBox();
            this.CbxDevice02_Baud = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CbxDevice02_COM = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbx_PLC = new System.Windows.Forms.GroupBox();
            this.ChBox_Enable = new System.Windows.Forms.CheckBox();
            this.CbxPLC_Baud = new System.Windows.Forms.ComboBox();
            this.CbxPLC_COM = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LabelDevice01 = new System.Windows.Forms.Label();
            this.LabelDevice02 = new System.Windows.Forms.Label();
            this.LabelPLC = new System.Windows.Forms.Label();
            this.LvDevice01 = new System.Windows.Forms.ListView();
            this.LvDevice02 = new System.Windows.Forms.ListView();
            this.columnHeaderNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNumber02 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderData02 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Device01Data = new System.Windows.Forms.Label();
            this.Device02Data = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Numeric = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.LabelMessage = new System.Windows.Forms.Label();
            this.columnHeaderNull = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbx_Device01.SuspendLayout();
            this.gbx_Device02.SuspendLayout();
            this.gbx_PLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // gbx_Device01
            // 
            this.gbx_Device01.Controls.Add(this.tbxDevice01_EndFlag);
            this.gbx_Device01.Controls.Add(this.tbxDevice01_BeginFlag);
            this.gbx_Device01.Controls.Add(this.CbxDevice01_Baud);
            this.gbx_Device01.Controls.Add(this.CbxDevice01_COM);
            this.gbx_Device01.Controls.Add(this.label5);
            this.gbx_Device01.Controls.Add(this.label6);
            this.gbx_Device01.Controls.Add(this.label2);
            this.gbx_Device01.Controls.Add(this.label1);
            this.gbx_Device01.Location = new System.Drawing.Point(12, 12);
            this.gbx_Device01.Name = "gbx_Device01";
            this.gbx_Device01.Size = new System.Drawing.Size(241, 203);
            this.gbx_Device01.TabIndex = 0;
            this.gbx_Device01.TabStop = false;
            this.gbx_Device01.Text = "设备1";
            // 
            // tbxDevice01_EndFlag
            // 
            this.tbxDevice01_EndFlag.Location = new System.Drawing.Point(77, 157);
            this.tbxDevice01_EndFlag.Name = "tbxDevice01_EndFlag";
            this.tbxDevice01_EndFlag.Size = new System.Drawing.Size(100, 21);
            this.tbxDevice01_EndFlag.TabIndex = 11;
            // 
            // tbxDevice01_BeginFlag
            // 
            this.tbxDevice01_BeginFlag.Location = new System.Drawing.Point(77, 119);
            this.tbxDevice01_BeginFlag.Name = "tbxDevice01_BeginFlag";
            this.tbxDevice01_BeginFlag.Size = new System.Drawing.Size(100, 21);
            this.tbxDevice01_BeginFlag.TabIndex = 10;
            // 
            // CbxDevice01_Baud
            // 
            this.CbxDevice01_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxDevice01_Baud.FormattingEnabled = true;
            this.CbxDevice01_Baud.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.CbxDevice01_Baud.Location = new System.Drawing.Point(77, 76);
            this.CbxDevice01_Baud.Name = "CbxDevice01_Baud";
            this.CbxDevice01_Baud.Size = new System.Drawing.Size(99, 20);
            this.CbxDevice01_Baud.TabIndex = 7;
            // 
            // CbxDevice01_COM
            // 
            this.CbxDevice01_COM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxDevice01_COM.FormattingEnabled = true;
            this.CbxDevice01_COM.Location = new System.Drawing.Point(77, 38);
            this.CbxDevice01_COM.Name = "CbxDevice01_COM";
            this.CbxDevice01_COM.Size = new System.Drawing.Size(99, 20);
            this.CbxDevice01_COM.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "终止符：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "起始符：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "端  口：";
            // 
            // gbx_Device02
            // 
            this.gbx_Device02.Controls.Add(this.tbxDevice02_EndFlag);
            this.gbx_Device02.Controls.Add(this.tbxDevice02_BeginFlag);
            this.gbx_Device02.Controls.Add(this.CbxDevice02_Baud);
            this.gbx_Device02.Controls.Add(this.label7);
            this.gbx_Device02.Controls.Add(this.CbxDevice02_COM);
            this.gbx_Device02.Controls.Add(this.label8);
            this.gbx_Device02.Controls.Add(this.label3);
            this.gbx_Device02.Controls.Add(this.label4);
            this.gbx_Device02.Location = new System.Drawing.Point(12, 221);
            this.gbx_Device02.Name = "gbx_Device02";
            this.gbx_Device02.Size = new System.Drawing.Size(241, 196);
            this.gbx_Device02.TabIndex = 1;
            this.gbx_Device02.TabStop = false;
            this.gbx_Device02.Text = "设备2";
            // 
            // tbxDevice02_EndFlag
            // 
            this.tbxDevice02_EndFlag.Location = new System.Drawing.Point(76, 157);
            this.tbxDevice02_EndFlag.Name = "tbxDevice02_EndFlag";
            this.tbxDevice02_EndFlag.Size = new System.Drawing.Size(100, 21);
            this.tbxDevice02_EndFlag.TabIndex = 13;
            // 
            // tbxDevice02_BeginFlag
            // 
            this.tbxDevice02_BeginFlag.Location = new System.Drawing.Point(76, 119);
            this.tbxDevice02_BeginFlag.Name = "tbxDevice02_BeginFlag";
            this.tbxDevice02_BeginFlag.Size = new System.Drawing.Size(100, 21);
            this.tbxDevice02_BeginFlag.TabIndex = 12;
            // 
            // CbxDevice02_Baud
            // 
            this.CbxDevice02_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxDevice02_Baud.FormattingEnabled = true;
            this.CbxDevice02_Baud.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.CbxDevice02_Baud.Location = new System.Drawing.Point(77, 73);
            this.CbxDevice02_Baud.Name = "CbxDevice02_Baud";
            this.CbxDevice02_Baud.Size = new System.Drawing.Size(99, 20);
            this.CbxDevice02_Baud.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "终止符：";
            // 
            // CbxDevice02_COM
            // 
            this.CbxDevice02_COM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxDevice02_COM.FormattingEnabled = true;
            this.CbxDevice02_COM.Location = new System.Drawing.Point(77, 35);
            this.CbxDevice02_COM.Name = "CbxDevice02_COM";
            this.CbxDevice02_COM.Size = new System.Drawing.Size(99, 20);
            this.CbxDevice02_COM.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "起始符：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "波特率：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "端  口：";
            // 
            // gbx_PLC
            // 
            this.gbx_PLC.Controls.Add(this.ChBox_Enable);
            this.gbx_PLC.Controls.Add(this.CbxPLC_Baud);
            this.gbx_PLC.Controls.Add(this.CbxPLC_COM);
            this.gbx_PLC.Controls.Add(this.label11);
            this.gbx_PLC.Controls.Add(this.label12);
            this.gbx_PLC.Location = new System.Drawing.Point(259, 12);
            this.gbx_PLC.Name = "gbx_PLC";
            this.gbx_PLC.Size = new System.Drawing.Size(488, 85);
            this.gbx_PLC.TabIndex = 12;
            this.gbx_PLC.TabStop = false;
            this.gbx_PLC.Text = "PLC";
            // 
            // ChBox_Enable
            // 
            this.ChBox_Enable.AutoSize = true;
            this.ChBox_Enable.Location = new System.Drawing.Point(404, 40);
            this.ChBox_Enable.Name = "ChBox_Enable";
            this.ChBox_Enable.Size = new System.Drawing.Size(48, 16);
            this.ChBox_Enable.TabIndex = 8;
            this.ChBox_Enable.Text = "启用";
            this.ChBox_Enable.UseVisualStyleBackColor = true;
            this.ChBox_Enable.CheckedChanged += new System.EventHandler(this.ChBox_Enable_CheckedChanged);
            // 
            // CbxPLC_Baud
            // 
            this.CbxPLC_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxPLC_Baud.FormattingEnabled = true;
            this.CbxPLC_Baud.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.CbxPLC_Baud.Location = new System.Drawing.Point(272, 38);
            this.CbxPLC_Baud.Name = "CbxPLC_Baud";
            this.CbxPLC_Baud.Size = new System.Drawing.Size(99, 20);
            this.CbxPLC_Baud.TabIndex = 7;
            // 
            // CbxPLC_COM
            // 
            this.CbxPLC_COM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxPLC_COM.FormattingEnabled = true;
            this.CbxPLC_COM.Location = new System.Drawing.Point(77, 38);
            this.CbxPLC_COM.Name = "CbxPLC_COM";
            this.CbxPLC_COM.Size = new System.Drawing.Size(99, 20);
            this.CbxPLC_COM.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(213, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "波特率：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "端  口：";
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(781, 16);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(78, 35);
            this.BtnOpen.TabIndex = 13;
            this.BtnOpen.Text = "连接";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(781, 57);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(78, 35);
            this.BtnClose.TabIndex = 14;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelStatus.Location = new System.Drawing.Point(271, 146);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 48);
            this.LabelStatus.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(277, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "绑定状态";
            // 
            // LabelDevice01
            // 
            this.LabelDevice01.AutoSize = true;
            this.LabelDevice01.Location = new System.Drawing.Point(277, 292);
            this.LabelDevice01.Name = "LabelDevice01";
            this.LabelDevice01.Size = new System.Drawing.Size(0, 12);
            this.LabelDevice01.TabIndex = 19;
            // 
            // LabelDevice02
            // 
            this.LabelDevice02.AutoSize = true;
            this.LabelDevice02.Location = new System.Drawing.Point(277, 337);
            this.LabelDevice02.Name = "LabelDevice02";
            this.LabelDevice02.Size = new System.Drawing.Size(0, 12);
            this.LabelDevice02.TabIndex = 20;
            // 
            // LabelPLC
            // 
            this.LabelPLC.AutoSize = true;
            this.LabelPLC.Location = new System.Drawing.Point(277, 379);
            this.LabelPLC.Name = "LabelPLC";
            this.LabelPLC.Size = new System.Drawing.Size(0, 12);
            this.LabelPLC.TabIndex = 21;
            // 
            // LvDevice01
            // 
            this.LvDevice01.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNull,
            this.columnHeaderNumber,
            this.columnHeaderData});
            this.LvDevice01.HideSelection = false;
            this.LvDevice01.Location = new System.Drawing.Point(404, 146);
            this.LvDevice01.Name = "LvDevice01";
            this.LvDevice01.Size = new System.Drawing.Size(236, 311);
            this.LvDevice01.TabIndex = 22;
            this.LvDevice01.UseCompatibleStateImageBehavior = false;
            this.LvDevice01.View = System.Windows.Forms.View.Details;
            // 
            // LvDevice02
            // 
            this.LvDevice02.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeaderNumber02,
            this.columnHeaderData02});
            this.LvDevice02.HideSelection = false;
            this.LvDevice02.Location = new System.Drawing.Point(646, 146);
            this.LvDevice02.Name = "LvDevice02";
            this.LvDevice02.Size = new System.Drawing.Size(235, 311);
            this.LvDevice02.TabIndex = 23;
            this.LvDevice02.UseCompatibleStateImageBehavior = false;
            this.LvDevice02.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNumber
            // 
            this.columnHeaderNumber.DisplayIndex = 0;
            this.columnHeaderNumber.Text = "序号";
            this.columnHeaderNumber.Width = 40;
            // 
            // columnHeaderData
            // 
            this.columnHeaderData.DisplayIndex = 1;
            this.columnHeaderData.Text = "数据1";
            this.columnHeaderData.Width = 196;
            // 
            // columnHeaderNumber02
            // 
            this.columnHeaderNumber02.DisplayIndex = 0;
            this.columnHeaderNumber02.Text = "序号";
            this.columnHeaderNumber02.Width = 40;
            // 
            // columnHeaderData02
            // 
            this.columnHeaderData02.DisplayIndex = 1;
            this.columnHeaderData02.Text = "数据2";
            this.columnHeaderData02.Width = 195;
            // 
            // Device01Data
            // 
            this.Device01Data.AutoSize = true;
            this.Device01Data.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Device01Data.ForeColor = System.Drawing.Color.Blue;
            this.Device01Data.Location = new System.Drawing.Point(402, 118);
            this.Device01Data.Name = "Device01Data";
            this.Device01Data.Size = new System.Drawing.Size(0, 20);
            this.Device01Data.TabIndex = 24;
            // 
            // Device02Data
            // 
            this.Device02Data.AutoSize = true;
            this.Device02Data.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Device02Data.ForeColor = System.Drawing.Color.Blue;
            this.Device02Data.Location = new System.Drawing.Point(644, 118);
            this.Device02Data.Name = "Device02Data";
            this.Device02Data.Size = new System.Drawing.Size(0, 20);
            this.Device02Data.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 434);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "扫描允许间隔：";
            // 
            // Numeric
            // 
            this.Numeric.Location = new System.Drawing.Point(133, 432);
            this.Numeric.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.Numeric.Name = "Numeric";
            this.Numeric.Size = new System.Drawing.Size(83, 21);
            this.Numeric.TabIndex = 27;
            this.Numeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Numeric.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numeric_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(222, 434);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 28;
            this.label13.Text = "ms";
            // 
            // LabelMessage
            // 
            this.LabelMessage.AutoSize = true;
            this.LabelMessage.ForeColor = System.Drawing.Color.Red;
            this.LabelMessage.Location = new System.Drawing.Point(277, 221);
            this.LabelMessage.Name = "LabelMessage";
            this.LabelMessage.Size = new System.Drawing.Size(0, 12);
            this.LabelMessage.TabIndex = 29;
            // 
            // columnHeaderNull
            // 
            this.columnHeaderNull.DisplayIndex = 2;
            this.columnHeaderNull.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 2;
            this.columnHeader1.Width = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 469);
            this.Controls.Add(this.LabelMessage);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.Numeric);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Device02Data);
            this.Controls.Add(this.Device01Data);
            this.Controls.Add(this.LvDevice02);
            this.Controls.Add(this.LvDevice01);
            this.Controls.Add(this.LabelPLC);
            this.Controls.Add(this.LabelDevice02);
            this.Controls.Add(this.LabelDevice01);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.gbx_PLC);
            this.Controls.Add(this.gbx_Device02);
            this.Controls.Add(this.gbx_Device01);
            this.Name = "FrmMain";
            this.Text = "串口通讯";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.gbx_Device01.ResumeLayout(false);
            this.gbx_Device01.PerformLayout();
            this.gbx_Device02.ResumeLayout(false);
            this.gbx_Device02.PerformLayout();
            this.gbx_PLC.ResumeLayout(false);
            this.gbx_PLC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_Device01;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbx_Device02;
        private System.Windows.Forms.TextBox tbxDevice01_EndFlag;
        private System.Windows.Forms.TextBox tbxDevice01_BeginFlag;
        private System.Windows.Forms.ComboBox CbxDevice01_Baud;
        private System.Windows.Forms.ComboBox CbxDevice01_COM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxDevice02_EndFlag;
        private System.Windows.Forms.TextBox tbxDevice02_BeginFlag;
        private System.Windows.Forms.ComboBox CbxDevice02_Baud;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CbxDevice02_COM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbx_PLC;
        private System.Windows.Forms.CheckBox ChBox_Enable;
        private System.Windows.Forms.ComboBox CbxPLC_Baud;
        private System.Windows.Forms.ComboBox CbxPLC_COM;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LabelDevice01;
        private System.Windows.Forms.Label LabelDevice02;
        private System.Windows.Forms.Label LabelPLC;
        private System.Windows.Forms.ListView LvDevice01;
        private System.Windows.Forms.ListView LvDevice02;
        private System.Windows.Forms.ColumnHeader columnHeaderNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderData;
        private System.Windows.Forms.ColumnHeader columnHeaderNumber02;
        private System.Windows.Forms.ColumnHeader columnHeaderData02;
        private System.Windows.Forms.Label Device01Data;
        private System.Windows.Forms.Label Device02Data;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown Numeric;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ColumnHeader columnHeaderNull;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label LabelMessage;
    }
}

