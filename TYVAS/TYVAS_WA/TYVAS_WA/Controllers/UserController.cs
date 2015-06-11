using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("~/api/User")]
        public string GetAllAttender()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.GetAllUser();
        }
    }
}
