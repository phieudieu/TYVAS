using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class AttenderController : ApiController
    {
        [HttpGet]
        [Route("~/api/Attender")]
         public List <Attender> GetAllAttender()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.GetAllAttender_T();           
        }
    }
}
