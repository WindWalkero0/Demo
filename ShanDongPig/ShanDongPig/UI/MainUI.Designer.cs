namespace ShanDongPig.UI
{
    partial class MainUI
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
            this.panelTitle = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.panelSelectButton = new DevExpress.XtraEditors.PanelControl();
            this.Btn_Setting = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Package = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Segmentation = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Slaughter = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Index = new DevExpress.XtraEditors.SimpleButton();
            this.MainPanel = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).BeginInit();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSelectButton)).BeginInit();
            this.panelSelectButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.labelControl1);
            this.panelTitle.Controls.Add(this.pictureEdit1);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1136, 100);
            this.panelTitle.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(367, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(560, 35);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "山东省健康肉风控及溯源一体化平台";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureEdit1.Location = new System.Drawing.Point(2, 2);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(187, 96);
            this.pictureEdit1.TabIndex = 0;
            // 
            // panelSelectButton
            // 
            this.panelSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSelectButton.Controls.Add(this.Btn_Setting);
            this.panelSelectButton.Controls.Add(this.Btn_Package);
            this.panelSelectButton.Controls.Add(this.Btn_Segmentation);
            this.panelSelectButton.Controls.Add(this.Btn_Slaughter);
            this.panelSelectButton.Controls.Add(this.Btn_Index);
            this.panelSelectButton.Location = new System.Drawing.Point(2, 100);
            this.panelSelectButton.Name = "panelSelectButton";
            this.panelSelectButton.Size = new System.Drawing.Size(1134, 82);
            this.panelSelectButton.TabIndex = 1;
            // 
            // Btn_Setting
            // 
            this.Btn_Setting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Setting.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Setting.Appearance.Options.UseFont = true;
            this.Btn_Setting.Location = new System.Drawing.Point(950, 24);
            this.Btn_Setting.Name = "Btn_Setting";
            this.Btn_Setting.Size = new System.Drawing.Size(115, 35);
            this.Btn_Setting.TabIndex = 4;
            this.Btn_Setting.Text = "设置";
            this.Btn_Setting.Click += new System.EventHandler(this.Btn_Setting_Click);
            // 
            // Btn_Package
            // 
            this.Btn_Package.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Package.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Package.Appearance.Options.UseFont = true;
            this.Btn_Package.Location = new System.Drawing.Point(727, 24);
            this.Btn_Package.Name = "Btn_Package";
            this.Btn_Package.Size = new System.Drawing.Size(115, 35);
            this.Btn_Package.TabIndex = 3;
            this.Btn_Package.Text = "包装";
            // 
            // Btn_Segmentation
            // 
            this.Btn_Segmentation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Segmentation.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Segmentation.Appearance.Options.UseFont = true;
            this.Btn_Segmentation.Location = new System.Drawing.Point(504, 24);
            this.Btn_Segmentation.Name = "Btn_Segmentation";
            this.Btn_Segmentation.Size = new System.Drawing.Size(115, 35);
            this.Btn_Segmentation.TabIndex = 2;
            this.Btn_Segmentation.Text = "分割";
            this.Btn_Segmentation.Click += new System.EventHandler(this.Btn_Segmentation_Click);
            // 
            // Btn_Slaughter
            // 
            this.Btn_Slaughter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Slaughter.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Slaughter.Appearance.Options.UseFont = true;
            this.Btn_Slaughter.Location = new System.Drawing.Point(281, 24);
            this.Btn_Slaughter.Name = "Btn_Slaughter";
            this.Btn_Slaughter.Size = new System.Drawing.Size(115, 35);
            this.Btn_Slaughter.TabIndex = 1;
            this.Btn_Slaughter.Text = "屠宰";
            this.Btn_Slaughter.Click += new System.EventHandler(this.Btn_Slaughter_Click);
            // 
            // Btn_Index
            // 
            this.Btn_Index.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Index.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Index.Appearance.Options.UseFont = true;
            this.Btn_Index.Location = new System.Drawing.Point(58, 24);
            this.Btn_Index.Name = "Btn_Index";
            this.Btn_Index.Size = new System.Drawing.Size(115, 35);
            this.Btn_Index.TabIndex = 0;
            this.Btn_Index.Text = "首页";
            this.Btn_Index.Click += new System.EventHandler(this.Btn_Index_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Location = new System.Drawing.Point(2, 182);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1134, 405);
            this.MainPanel.TabIndex = 5;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 587);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panelSelectButton);
            this.Controls.Add(this.panelTitle);
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "山东省健康肉风控及溯源一体化平台";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSelectButton)).EndInit();
            this.panelSelectButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTitle;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.PanelControl panelSelectButton;
        private DevExpress.XtraEditors.SimpleButton Btn_Setting;
        private DevExpress.XtraEditors.SimpleButton Btn_Package;
        private DevExpress.XtraEditors.SimpleButton Btn_Segmentation;
        private DevExpress.XtraEditors.SimpleButton Btn_Slaughter;
        private DevExpress.XtraEditors.SimpleButton Btn_Index;
        private DevExpress.XtraEditors.PanelControl MainPanel;
    }
}