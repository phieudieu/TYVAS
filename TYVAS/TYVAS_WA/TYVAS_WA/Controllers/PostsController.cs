using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class PostsController : ApiController
    {
        [HttpGet]
        [Route("~/api/Posts")]
        public string  GetAllAttender()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Posts> lst = da.GetAllPosts_T();
            return da.Object2Json(lst, "Posts", lst.Count);
        }

        [HttpGet]
        [Route("~/api/Posts/{pid}")]
        public string GetAllAttender(int pid = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Posts> lst = da.GetAllPosts_T(pid);
            return da.Object2Json(lst, "Posts", lst.Count);
        }

    }
}
