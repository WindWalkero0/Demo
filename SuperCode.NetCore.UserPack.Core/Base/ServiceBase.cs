using SuperCode.Standard.UserPack.Core.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCode.Standard.UserPack.Core.Base
{
    internal class ServiceBase
    {
        internal ProductOperateContext Db
        {
            get
            {
                return this.GetService<ProductOperateContext>();
            }
        }
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        /// <returns></returns>
        public T GetService<T>(string name = null, string paramName = null, string paramValue = null) where T : class
        {
            return App.Core.AppStandardContext.Current.Resolve<T>(name, paramName, paramValue);
        }
        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="tableName"></param>
        public void CreateWareHouseTable()
        {
            Db.Execute(@"CREATE TABLE if not exists WareHouse " + @"(
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(100) DEFAULT NULL COMMENT '产品名称',
  `ProductBatch` varchar(50) DEFAULT NULL COMMENT '产品批次',
  `WarehouseName` varchar(50) DEFAULT NULL COMMENT '库房名称',
  `CreationTime` TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `ProductBatch` (`ProductBatch`) USING BTREE,
  KEY `CreationTime` (`CreationTime`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;");
        }
    }
}
