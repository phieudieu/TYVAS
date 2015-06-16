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
        public string GetAllSharing()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Sharing> lst = da.GetAllSharing_T();
            return da.Object2Json(lst, "Sharing", lst.Count);
        }

        [HttpGet]
        [Route("~/api/Sharing/{id}")]
        public string GetSharingBy(int id = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Sharing> lst = da.GetAllSharing_T(id);
            return da.Object2Json(lst, "Sharing", lst.Count);
        }

        [HttpGet]
        [Route("~/api/Paging/Sharing/{PageNumber}/{RowspPage}")]
        public string GetAllSharingPaging(int PageNumber, int RowspPage)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Sharing> lst = da.GetAllSharingPaging_T(PageNumber, RowspPage);
            return da.Object2Json(lst, "Sharing", lst.Count, da.CountDataFromTable("Sharing"));
        }

        [HttpPost]
        [Route("~/api/Sharing")]
        public string InsertSharing(Sharing obj)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.InsertSharing(obj).ToString();
        }
        
        [HttpDelete ]
        [Route("~/api/Sharing/{id}")]
        public string DeleteSharing(int id)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.DeleteSharing(id).ToString();
        }

        [HttpPut]
        [Route("~/api/Sharing/{arraycolumn}")]
        public string UpdateSharing(Sharing obj, string[] arraycolumn)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.UpdateSharing(obj,arraycolumn ).ToString();
        }

    }
}
