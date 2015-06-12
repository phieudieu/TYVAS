using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class SponsorController : ApiController
    {
       
        [HttpGet]
        [Route("~/api/Sponsor")]
        public string  GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Sponsor> lst = da.GetAllSponsor_T();
            return da.Object2Json(lst, "Sponsor", lst.Count);
        }

    }
}
