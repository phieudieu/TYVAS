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
        public List<Comment> GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.GetAllComment_T();
        }
    }
}
