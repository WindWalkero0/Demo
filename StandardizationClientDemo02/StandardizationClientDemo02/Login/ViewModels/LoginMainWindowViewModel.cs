using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using StandardizationClientDemo02.Login.Views;
using StandardizationClientDemo02.SystemConfiguration.ObjectClasses;
using Microsoft.Practices.Prism.ViewModel;

namespace StandardizationClientDemo02.Login.ViewModels
{
    public class LoginMainWindowViewModel : NotificationObject
    {
        public LoginMainWindow hostWindow = null;

        private CS_User _user;
        public CS_User User
        {
            get { return _user; }
            set { _user = value; this.RaisePropertyChanged("user"); }
        }

        private bool _isRememberUserInfo;
        /// <summary>
        /// 是否记住用户信息
        /// 【true】记住|【false】不记
        /// </summary>
        public bool IsRememberUserInfo
        {
            get { return _isRememberUserInfo; }
            set { _isRememberUserInfo = value;this.RaisePropertyChanged("isRememberUserInfo"); }
        }

        private bool _isOnLine;
        /// <summary>
        /// 是否离线
        /// 【true】在线|【false】离线
        /// </summary>
        public bool IsOnLine
        {
            get { return _isOnLine; }
            set { _isOnLine = value;this.RaisePropertyChanged("isOnLine"); }
        }


        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }

        public LoginMainWindowViewModel()
        {
            Init();
            InitCommand();
        }

        private void Init()
        {
            User = new CS_User();
            User.UserName = "";
            User.Password = "";
        }

        private void InitCommand()
        {
            LoginCommand = new DelegateCommand(new Action(Client_Login));
            ExitCommand = new DelegateCommand(new Action(Client_Exit));
        }
        /// <summary>
        /// 登录
        /// </summary>
        public void Client_Login()
        {
            int Retcode = LoginVerify(User.UserName, User.Password);
            if(0 == Retcode)
            {
                try
                {
                    hostWindow.DialogResult = true;
                }
                catch(Exception e)
                {
                    hostWindow.Close();
                }
            }
            else
            {
                string errTxt = GetErrormsgFormCode(Retcode);
                return;
            }
        }
        /// <summary>
        /// 退出
        /// </summary>
        private void Client_Exit()
        {
            hostWindow.Close();
        }
        /// <summary>
        /// 登录认证返回的状态
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        int LoginVerify(string username, string password)
        {
            try
            {

                return 0;
            }
            catch (System.Exception ex)
            {
                return -3;
            }
        }

        private string GetErrormsgFormCode(int Retcode)
        {
            switch(Retcode)
            {
                case -1:
                    return "登录用户不存在";
                case -2:
                    return "登录密码不正确";
                case -3:
                    return "数据库连接错误，请检查连接参数是否正确!";
                default:
                    return "位置错误!";
            }
        }
    }
}
