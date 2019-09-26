using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App

namespace SuperCode.NetCore.UserPack.Api.Extensions
{
    public static class ControllerExtension
    {
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <param name="controllerBase"></param>
        /// <returns></returns>
        public static T GetService(this ControllerBase controllerBase)
        {
            var service = AppStandardContext
        }
    }
}
