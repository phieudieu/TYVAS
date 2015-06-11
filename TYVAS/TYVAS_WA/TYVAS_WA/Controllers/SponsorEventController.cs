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
            return da.GetAllSponsorEvent();
        }

    }
}
