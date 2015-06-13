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

        [HttpGet]
        [Route("~/api/Sponsor/{id}")]
        public string GetAllAttenderAndSponsor(int id = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Sponsor> lst = da.GetAllSponsor_T(id);
            return da.Object2Json(lst, "Sponsor", lst.Count);
        }

    }
}
