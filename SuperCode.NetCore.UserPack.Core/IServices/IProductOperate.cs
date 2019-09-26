using SuperCode.Standard.UserPack.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCode.Standard.UserPack.Core.IServices
{
    /// <summary>
    /// 产品操作
    /// </summary>
    public interface IProductOperate
    {
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="addProductDto"></param>
        /// <returns></returns>
        bool AddProduct(AddProductDto addProductDto);

    }
}
