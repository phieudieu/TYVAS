using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class CommentController : ApiController
    {
        [HttpGet]
        [Route("~/api/Comment")]
        public  string  GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Comment> lst = da.GetAllComment_T();
            return da.Object2Json(lst, "Comment", lst.Count);
        }

        [HttpGet]
        [Route("~/api/Comment/{id}")]
        public string GetAllAttenderAndSponsor(int id = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Comment> lst = da.GetAllComment_T(id);
            return da.Object2Json(lst, "Comment", lst.Count);
        }



    }
}
