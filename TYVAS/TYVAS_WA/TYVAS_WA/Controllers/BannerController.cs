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
        public string GetAllBanner()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Banner> lst = da.GetAllBanner_T();
            return da.Object2Json(lst, "Banner", lst.Count);
        }

        [HttpGet]
        [Route("~/api/Banner/{id}")]
        public string GetAttenderBannerBy(int id = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Banner> lst = da.GetAllBanner_T(id);
            return da.Object2Json(lst, "Banner", lst.Count);
        }

        [HttpPost]
        [Route("~/api/Banner")]
        public string InsertBanner(Banner obj)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.InsertBanner(obj).ToString();
        }

        [HttpDelete ]
        [Route("~/api/Banner/{id}")]
        public string DeleteBanner(int id = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.DeleteBanner( id).ToString ();
        }

    }
}
