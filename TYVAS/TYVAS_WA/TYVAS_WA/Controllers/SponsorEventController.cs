using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class SponsorEventController : ApiController
    {
        [HttpGet]
        [Route("~/api/SponsorEvent")]
        public string  GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<SponsorEvent> lst = da.GetAllSponsorEvent_T();
            return da.Object2Json(lst, "SponsorEvent", lst.Count);
        }

        [HttpGet]
        [Route("~/api/SponsorEvent/{IDSponsor}/{IDEvent}")]
        public string GetAllAttenderAndSponsor(int IDSponsor = -1, int IDEvent = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<SponsorEvent> lst = da.GetAllSponsorEvent_T(IDSponsor, IDEvent);
            return da.Object2Json(lst, "SponsorEvent", lst.Count);
        }

    }
}
