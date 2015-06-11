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
        public string GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Banner> lst = da.GetAllBanner_T();
            return da.Object2Json(lst, "Banner", lst.Count);
        }

    }
}
