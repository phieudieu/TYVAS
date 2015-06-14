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
        public string GetAllTYASInfo()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<TYASInfo> lst = da.GetAllTYASInfo_T();
            return da.Object2Json(lst, "TYASInfo", lst.Count);
        }

        [HttpGet]
        [Route("~/api/TYASInfo/{id}")]
        public string GetTYASInfoBy(int id = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<TYASInfo> lst = da.GetAllTYASInfo_T(id);
            return da.Object2Json(lst, "TYASInfo", lst.Count);
        }

        [HttpPost]
        [Route("~/api/TYASInfo")]
        public string InsertTYASInfo(TYASInfo obj)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.InsertTYASInfo(obj).ToString();
        }

        [HttpDelete ]
        [Route("~/api/TYASInfo/{id}")]
        public string DeleteTYASInfo(int id)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.DeleteTYASInfo(id).ToString();
        }

    }
}
