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
        public List<Posts> GetAllAttender()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.GetAllPosts_T();
        }
    }
}
