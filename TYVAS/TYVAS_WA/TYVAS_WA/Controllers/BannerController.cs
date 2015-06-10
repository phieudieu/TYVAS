using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class BannerController : ApiController
    {
        [HttpGet]
        [Route("~/api/Banner")]
        public List<Banner> GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.GetAllBanner_T();
        }

    }
}
