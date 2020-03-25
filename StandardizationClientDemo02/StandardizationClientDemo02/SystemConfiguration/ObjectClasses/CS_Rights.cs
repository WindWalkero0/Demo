using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;

namespace StandardizationClientDemo02.SystemConfiguration.ObjectClasses
{
    public class CS_Rights : NotificationObject
    {
        private string _id;
        /// <summary>
        /// 权限唯一标识
        /// </summary>
        public string ID
        {
            get { return _id; }
            set { _id = value; this.RaisePropertyChanged("id"); }
        }

        private string _rightName;
        /// <summary>
        /// 权限名称
        /// </summary>
        public string RightName
        {
            get { return _rightName; }
            set { _rightName = value;this.RaisePropertyChanged("rightName"); }
        }
    }
}
