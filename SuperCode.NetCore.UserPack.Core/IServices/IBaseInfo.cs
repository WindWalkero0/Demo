using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCode.Standard.UserPack.Core.IServices
{
    public interface IBaseInfo
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        string ProductName { get; set; }
        /// <summary>
        /// 库房名称
        /// </summary>
        string WarehouseName { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        DateTime OperateTime { get; set; }
    }
}
