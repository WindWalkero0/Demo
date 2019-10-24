using Microsoft.AspNetCore.Mvc;
using SuperCode.NetCore.UserPack.Api.Extensions;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SuperCode.NetCore.Digital.Api.Controllers
{
    [Route("api/UserPack/{controller}/{action}")]
    [ApiController]
    public partial class ProductController : ControllerBase
    {
        public System.Boolean Add([FromBody]SuperCode.Standard.UserPack.Core.Dtos.AddProductDto addProductDto)
        {
            var service = this.GetService<SuperCode.Standard.UserPack.Core.IServices.IProductOperate>();
            return
        }
    }
}
