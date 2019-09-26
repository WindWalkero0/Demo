using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCode.Standard.UserPack.Core.Dtos
{
    /// <summary>
    ///数据传输对象
    /// </summary>
    public class AddProductDto
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 产品批次
        /// </summary>
        public string ProductBatch { get; set; }
        /// <summary>
        /// 库房名称
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 起始码
        /// </summary>
        public string BeginCode { get; set; }
        /// <summary>
        /// 结束码
        /// </summary>
        public string EndCode { get; set; }
        /// <summary>
        /// 单码
        /// </summary>
        public string SingleCode { get; set; }
    }
}
