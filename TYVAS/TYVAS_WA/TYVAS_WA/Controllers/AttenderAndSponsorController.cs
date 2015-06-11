using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class AttenderAndSponsorController : ApiController
    {
        //[HttpGet]
        //[Route("~/api/AttenderAndSponsor")]
        //public List<AttenderAndSponsor> GetAllAttenderAndSponsor()
        //{
        //    MsSqlDataAccess da = new MsSqlDataAccess();
        //    return da.GetAllAttenderAndSponsor_T();
        //}
        [HttpGet]
        [Route("~/api/AttenderAndSponsor")]
        public string  GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.GetAllAttenderAndSponsor();
        }

    }
}
