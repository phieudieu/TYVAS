using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class AttenderAndSponsorController : ApiController
    {
       
        [HttpGet]
        [Route("~/api/AttenderAndSponsor")]
        public string  GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List< AttenderAndSponsor > lst = da.GetAllAttenderAndSponsor_T();
            return da.Object2Json(lst, "AttenderAndSponsor", lst.Count);
        }

    }
}
