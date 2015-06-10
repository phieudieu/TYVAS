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
        public List<Sharing> GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.GetAllSharing_T();
        }

    }
}
