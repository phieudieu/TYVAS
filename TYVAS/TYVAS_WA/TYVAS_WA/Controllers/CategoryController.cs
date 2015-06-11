using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class CategoryController : ApiController
    {

        [HttpGet]
        [Route("~/api/Category")]
        public string GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Category> lst = da.GetAllCategory_T();
            return da.Object2Json(lst, "Category", lst.Count);
        }
    }
}
