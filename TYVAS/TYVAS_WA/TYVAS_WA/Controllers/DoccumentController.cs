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
        public string  GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Doccument> lst = da.GetAllDoccument_T();
            return da.Object2Json(lst, "Doccument", lst.Count);
        }
    }
}
