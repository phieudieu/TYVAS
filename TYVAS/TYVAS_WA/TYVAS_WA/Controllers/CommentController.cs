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
        public string GetComment()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Comment> lst = da.GetAllComment_T();
            return da.Object2Json(lst, "Comment", lst.Count);
        }

        [HttpGet]
        [Route("~/api/Comment/{id}")]
        public string GetCommentBy(int id = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Comment> lst = da.GetAllComment_T(id);
            return da.Object2Json(lst, "Comment", lst.Count);
        }

        [HttpPost]
        [Route("~/api/Comment")]
        public string InsertComment(Comment obj)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.InsertComment(obj).ToString();
        }

        [HttpDelete ]
        [Route("~/api/Comment/{id}")]
        public string InsertComment(int id)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.DeleteComment(id).ToString();
        }
    }
}
