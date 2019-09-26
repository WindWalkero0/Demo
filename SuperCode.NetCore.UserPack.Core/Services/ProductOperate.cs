using SuperCode.Standard.UserPack.Core.Dtos;
using SuperCode.Standard.UserPack.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using SuperCode.Standard.UserPack.Core.Base;

namespace SuperCode.Standard.UserPack.Core.Services
{
    class ProductOperate : ServiceBase, IProductOperate
    {
        public bool AddProduct(AddProductDto addProductDto)
        {
            CreateWareHouseTable();
            using (var trans = Db.GetTransaction())
            {
                try
                {
                    Db.Execute("INSERT INTO WareHouse(ProductName, ProductBatch, WarehouseName) VALUES(@0, @1, @2) ",
                        addProductDto.ProductName, addProductDto.ProductBatch, addProductDto.WarehouseName);
                    trans.Complete();
                    return true;
                }
                catch(Exception ex)
                {
                    throw new Exception($"系统错误:{ex.Message}");
                }
            }
        }

        public 
    }
}
