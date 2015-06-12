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
            List<Users> lst = da.GetAllUser_T();
            return da.Object2Json(lst, "Users", lst.Count);
        }
    }
}
