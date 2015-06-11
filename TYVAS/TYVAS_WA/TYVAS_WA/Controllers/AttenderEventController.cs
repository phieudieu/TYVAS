using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class AttenderEventController : ApiController
    {
        //[HttpGet]
        //[Route("~/api/AttenderEvent")]
        //public List<AttenderEvent> GetAllAttenderAndSponsor()
        //{
        //    MsSqlDataAccess da = new MsSqlDataAccess();
        //    return da.GetAllAttenderEvent_T();
        //}
        [HttpGet]
        [Route("~/api/AttenderEvent")]
        public string GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.GetAllAttenderEvent();
        }

    }
}
