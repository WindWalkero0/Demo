namespace ShanDongPig.UI
{
    partial class Login
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
            this.Btn_Login = new DevExpress.XtraEditors.SimpleButton();
            this.txtBox_Pwd = new DevExpress.XtraEditors.TextEdit();
            this.txtBox_User = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtBox_Pwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBox_User.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Login
            // 
            this.Btn_Login.AllowFocus = false;
            this.Btn_Login.Appearance.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Login.Appearance.Options.UseFont = true;
            this.Btn_Login.Location = new System.Drawing.Point(26, 117);
            this.Btn_Login.LookAndFeel.SkinName = "Office 2010 Blue";
            this.Btn_Login.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(255, 47);
            this.Btn_Login.TabIndex = 12;
            this.Btn_Login.Text = "登录";
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // txtBox_Pwd
            // 
            this.txtBox_Pwd.Location = new System.Drawing.Point(76, 66);
            this.txtBox_Pwd.Name = "txtBox_Pwd";
            this.txtBox_Pwd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtBox_Pwd.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_Pwd.Properties.Appearance.Options.UseFont = true;
            this.txtBox_Pwd.Properties.PasswordChar = '●';
            this.txtBox_Pwd.Size = new System.Drawing.Size(205, 22);
            this.txtBox_Pwd.TabIndex = 11;
            // 
            // txtBox_User
            // 
            this.txtBox_User.Location = new System.Drawing.Point(76, 23);
            this.txtBox_User.Name = "txtBox_User";
            this.txtBox_User.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_User.Properties.Appearance.Options.UseFont = true;
            this.txtBox_User.Size = new System.Drawing.Size(205, 22);
            this.txtBox_User.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(23, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "密 码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "账 号:";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 197);
            this.Controls.Add(this.Btn_Login);
            this.Controls.Add(this.txtBox_Pwd);
            this.Controls.Add(this.txtBox_User);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Login1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBox_Pwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBox_User.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Btn_Login;
        private DevExpress.XtraEditors.TextEdit txtBox_Pwd;
        private DevExpress.XtraEditors.TextEdit txtBox_User;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}