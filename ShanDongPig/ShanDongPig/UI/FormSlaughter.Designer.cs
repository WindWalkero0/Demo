namespace ShanDongPig.UI
{
    partial class FormSlaughter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.Btn_Start = new DevExpress.XtraEditors.SimpleButton();
            this.GridControl_Slaughter = new DevExpress.XtraGrid.GridControl();
            this.GridView_Slaughter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Number = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BatchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EarNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CableTieCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodeSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SlaughterTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeheadTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AcidRemovalTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UploadResult = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl_Slaughter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView_Slaughter)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Start
            // 
            this.Btn_Start.AllowFocus = false;
            this.Btn_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Start.Appearance.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Btn_Start.Appearance.BackColor2 = System.Drawing.SystemColors.MenuHighlight;
            this.Btn_Start.Appearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.Btn_Start.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Start.Appearance.ForeColor = System.Drawing.Color.White;
            this.Btn_Start.Appearance.Options.UseBackColor = true;
            this.Btn_Start.Appearance.Options.UseBorderColor = true;
            this.Btn_Start.Appearance.Options.UseFont = true;
            this.Btn_Start.Appearance.Options.UseForeColor = true;
            this.Btn_Start.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Btn_Start.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Btn_Start.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Btn_Start.AppearanceHovered.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Start.AppearanceHovered.Options.UseBackColor = true;
            this.Btn_Start.AppearanceHovered.Options.UseBorderColor = true;
            this.Btn_Start.AppearanceHovered.Options.UseFont = true;
            this.Btn_Start.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Btn_Start.Location = new System.Drawing.Point(763, 431);
            this.Btn_Start.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.Btn_Start.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(103, 30);
            this.Btn_Start.TabIndex = 0;
            this.Btn_Start.Text = "开始";
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // GridControl_Slaughter
            // 
            this.GridControl_Slaughter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControl_Slaughter.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.RelationName = "Level1";
            this.GridControl_Slaughter.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.GridControl_Slaughter.Location = new System.Drawing.Point(63, 31);
            this.GridControl_Slaughter.MainView = this.GridView_Slaughter;
            this.GridControl_Slaughter.Name = "GridControl_Slaughter";
            this.GridControl_Slaughter.Size = new System.Drawing.Size(780, 381);
            this.GridControl_Slaughter.TabIndex = 1;
            this.GridControl_Slaughter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView_Slaughter});
            // 
            // GridView_Slaughter
            // 
            this.GridView_Slaughter.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.GridView_Slaughter.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridView_Slaughter.Appearance.Row.Options.UseTextOptions = true;
            this.GridView_Slaughter.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridView_Slaughter.ColumnPanelRowHeight = 30;
            this.GridView_Slaughter.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Number,
            this.BatchName,
            this.EarNumber,
            this.CableTieCode,
            this.CodeSource,
            this.SlaughterTime,
            this.DeheadTime,
            this.AcidRemovalTime,
            this.UploadResult});
            this.GridView_Slaughter.GridControl = this.GridControl_Slaughter;
            this.GridView_Slaughter.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.GridView_Slaughter.Name = "GridView_Slaughter";
            this.GridView_Slaughter.OptionsBehavior.Editable = false;
            this.GridView_Slaughter.OptionsCustomization.AllowColumnResizing = false;
            this.GridView_Slaughter.OptionsCustomization.AllowFilter = false;
            this.GridView_Slaughter.OptionsCustomization.AllowSort = false;
            this.GridView_Slaughter.OptionsMenu.EnableColumnMenu = false;
            this.GridView_Slaughter.OptionsView.ShowGroupPanel = false;
            this.GridView_Slaughter.OptionsView.ShowIndicator = false;
            this.GridView_Slaughter.RowHeight = 30;
            this.GridView_Slaughter.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // Number
            // 
            this.Number.AppearanceCell.Options.UseTextOptions = true;
            this.Number.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Number.AppearanceHeader.Options.UseTextOptions = true;
            this.Number.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Number.Caption = "序号";
            this.Number.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Number.Name = "Number";
            this.Number.Visible = true;
            this.Number.VisibleIndex = 0;
            this.Number.Width = 49;
            // 
            // BatchName
            // 
            this.BatchName.AppearanceCell.Options.UseTextOptions = true;
            this.BatchName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BatchName.AppearanceHeader.Options.UseTextOptions = true;
            this.BatchName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BatchName.Caption = "进场批次";
            this.BatchName.Name = "BatchName";
            this.BatchName.Visible = true;
            this.BatchName.VisibleIndex = 1;
            this.BatchName.Width = 63;
            // 
            // EarNumber
            // 
            this.EarNumber.AppearanceCell.Options.UseTextOptions = true;
            this.EarNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EarNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.EarNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EarNumber.Caption = "耳标号";
            this.EarNumber.Name = "EarNumber";
            this.EarNumber.Visible = true;
            this.EarNumber.VisibleIndex = 2;
            this.EarNumber.Width = 62;
            // 
            // CableTieCode
            // 
            this.CableTieCode.AppearanceCell.Options.UseTextOptions = true;
            this.CableTieCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CableTieCode.AppearanceHeader.Options.UseTextOptions = true;
            this.CableTieCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CableTieCode.Caption = "扎带码";
            this.CableTieCode.Name = "CableTieCode";
            this.CableTieCode.Visible = true;
            this.CableTieCode.VisibleIndex = 3;
            this.CableTieCode.Width = 63;
            // 
            // CodeSource
            // 
            this.CodeSource.AppearanceCell.Options.UseTextOptions = true;
            this.CodeSource.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CodeSource.AppearanceHeader.Options.UseTextOptions = true;
            this.CodeSource.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CodeSource.Caption = "扎带码来源";
            this.CodeSource.Name = "CodeSource";
            this.CodeSource.Visible = true;
            this.CodeSource.VisibleIndex = 4;
            this.CodeSource.Width = 63;
            // 
            // SlaughterTime
            // 
            this.SlaughterTime.AppearanceCell.Options.UseTextOptions = true;
            this.SlaughterTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SlaughterTime.AppearanceHeader.Options.UseTextOptions = true;
            this.SlaughterTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SlaughterTime.Caption = "屠宰时间";
            this.SlaughterTime.Name = "SlaughterTime";
            this.SlaughterTime.Visible = true;
            this.SlaughterTime.VisibleIndex = 5;
            this.SlaughterTime.Width = 63;
            // 
            // DeheadTime
            // 
            this.DeheadTime.AppearanceCell.Options.UseTextOptions = true;
            this.DeheadTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DeheadTime.AppearanceHeader.Options.UseTextOptions = true;
            this.DeheadTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DeheadTime.Caption = "去头时间";
            this.DeheadTime.Name = "DeheadTime";
            this.DeheadTime.Visible = true;
            this.DeheadTime.VisibleIndex = 6;
            this.DeheadTime.Width = 66;
            // 
            // AcidRemovalTime
            // 
            this.AcidRemovalTime.AppearanceCell.Options.UseTextOptions = true;
            this.AcidRemovalTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AcidRemovalTime.AppearanceHeader.Options.UseTextOptions = true;
            this.AcidRemovalTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AcidRemovalTime.Caption = "排酸更新";
            this.AcidRemovalTime.DisplayFormat.FormatString = "\"yyyy/MM/dd HH:mm:ss.fff\"";
            this.AcidRemovalTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.AcidRemovalTime.Name = "AcidRemovalTime";
            this.AcidRemovalTime.Visible = true;
            this.AcidRemovalTime.VisibleIndex = 7;
            this.AcidRemovalTime.Width = 85;
            // 
            // UploadResult
            // 
            this.UploadResult.AppearanceCell.Options.UseTextOptions = true;
            this.UploadResult.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UploadResult.AppearanceHeader.Options.UseTextOptions = true;
            this.UploadResult.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UploadResult.Caption = "上传结果";
            this.UploadResult.Name = "UploadResult";
            this.UploadResult.Visible = true;
            this.UploadResult.VisibleIndex = 8;
            this.UploadResult.Width = 115;
            // 
            // FormSlaughter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(915, 493);
            this.Controls.Add(this.GridControl_Slaughter);
            this.Controls.Add(this.Btn_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSlaughter";
            this.Text = "FormSlaughter";
            this.Load += new System.EventHandler(this.FormSlaughter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl_Slaughter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView_Slaughter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Btn_Start;
        private DevExpress.XtraGrid.GridControl GridControl_Slaughter;
        private DevExpress.XtraGrid.Views.Grid.GridView GridView_Slaughter;
        private DevExpress.XtraGrid.Columns.GridColumn Number;
        private DevExpress.XtraGrid.Columns.GridColumn BatchName;
        private DevExpress.XtraGrid.Columns.GridColumn EarNumber;
        private DevExpress.XtraGrid.Columns.GridColumn CableTieCode;
        private DevExpress.XtraGrid.Columns.GridColumn CodeSource;
        private DevExpress.XtraGrid.Columns.GridColumn SlaughterTime;
        private DevExpress.XtraGrid.Columns.GridColumn DeheadTime;
        private DevExpress.XtraGrid.Columns.GridColumn AcidRemovalTime;
        private DevExpress.XtraGrid.Columns.GridColumn UploadResult;
    }
}