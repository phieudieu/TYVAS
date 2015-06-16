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
        public string GetAllPosts()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Posts> lst = da.GetAllPosts_T();
            return da.Object2Json(lst, "Posts", lst.Count);
        }

        [HttpGet]
        [Route("~/api/Posts/{pid}")]
        public string GetPostsBy(int pid = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Posts> lst = da.GetAllPosts_T(pid);
            return da.Object2Json(lst, "Posts", lst.Count);
        }

        [HttpGet]
        [Route("~/api/Paging/Posts/{PageNumber}/{RowspPage}")]
        public string GetAllPostsPaging(int PageNumber, int RowspPage)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Posts> lst = da.GetAllPostsPaging_T (PageNumber, RowspPage);
            return da.Object2Json(lst, "Posts", lst.Count, da.CountDataFromTable("Posts"));
        }

        [HttpPost]
        [Route("~/api/Posts")]
        public string InsertPosts(Posts obj)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.InsertPosts(obj).ToString();
        }

        [HttpDelete ]
        [Route("~/api/Posts/{pid}")]
        public string DeletePosts(int pid)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.DeletePosts(pid).ToString();
        }

        [HttpPut]
        [Route("~/api/Posts/{arraycolumn}")]
        public string UpdatePosts(Posts obj, string[] arraycolumn)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.UpdatePosts(obj,arraycolumn ).ToString();
        }

    }
}
