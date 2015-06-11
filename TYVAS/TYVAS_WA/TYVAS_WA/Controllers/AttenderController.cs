﻿using System;
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
        public string  GetAllAttender()
        {
           MsSqlDataAccess da = new MsSqlDataAccess();
           List<Attender> lst = da.GetAllAttender_T();
           return da.Object2Json(lst, "Attender", lst.Count);
          
        }

        
    }
}
