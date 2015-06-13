using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class TYASInfoController : ApiController
    {
        [HttpGet]
        [Route("~/api/TYASInfo")]
        public string GetAllAttender()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<TYASInfo> lst = da.GetAllTYASInfo_T();
            return da.Object2Json(lst, "TYASInfo", lst.Count);
        }

        [HttpGet]
        [Route("~/api/TYASInfo/{id}")]
        public string GetAllAttender(int id = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<TYASInfo> lst = da.GetAllTYASInfo_T(id);
            return da.Object2Json(lst, "TYASInfo", lst.Count);
        }

    }
}
