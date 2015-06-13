using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class SharingController : ApiController
    {
        [HttpGet]
        [Route("~/api/Sharing")]
        public string  GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Sharing> lst = da.GetAllSharing_T();
            return da.Object2Json(lst, "Sharing", lst.Count);
        }

        [HttpGet]
        [Route("~/api/Sharing/{id}")]
        public string GetAllAttenderAndSponsor(int id = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Sharing> lst = da.GetAllSharing_T(id);
            return da.Object2Json(lst, "Sharing", lst.Count);
        }

    }
}
