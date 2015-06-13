using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class DoccumentController : ApiController
    {
        [HttpGet]
        [Route("~/api/Doccument")]
        public string GetAllDoccument()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Doccument> lst = da.GetAllDoccument_T();
            return da.Object2Json(lst, "Doccument", lst.Count);
        }

        [HttpGet]
        [Route("~/api/Doccument/{id}")]
        public string GetDoccumentBy(int id = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Doccument> lst = da.GetAllDoccument_T(  id );
            return da.Object2Json(lst, "Doccument", lst.Count);
        }

        [HttpPost]
        [Route("~/api/Doccument")]
        public string InsertDoccument(Doccument obj)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.InsertDoccument(obj).ToString();
        }

    }
}
