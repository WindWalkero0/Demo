using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;

namespace StandardizationClientDemo02.SystemConfiguration.ObjectClasses
{
    public class CS_User : NotificationObject
    {
        private string _id;
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string ID
        {
            get { return _id; }
            set { _id = value; this.RaisePropertyChanged("id"); }
        }

        private string _userName;
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; this.RaisePropertyChanged("userName"); }
        }

        private string _password;
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; this.RaisePropertyChanged("password"); }
        }

        private string _perssion;
        /// <summary>
        /// 用户权限
        /// </summary>
        public string Perssion
        {
            get { return _perssion; }
            set { _perssion = value; this.RaisePropertyChanged("perssion"); }
        }

        public DelegateCommand<object> EditCommand { get; set; }
        public DelegateCommand<object> DeleteCommand { get; set; }
        public DelegateCommand<object> ResetPasswordCommand { get; set; }
    }
}
