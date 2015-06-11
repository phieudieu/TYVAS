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
        //[HttpGet]
        //[Route("~/api/Category")]
        //public List<Category> GetAllAttenderAndSponsor()
        //{
        //    MsSqlDataAccess da = new MsSqlDataAccess();
        //    return da.GetAllCategory_T();
        //}

        [HttpGet]
        [Route("~/api/Category")]
        public string GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.GetAllCategory();
        }
    }
}
