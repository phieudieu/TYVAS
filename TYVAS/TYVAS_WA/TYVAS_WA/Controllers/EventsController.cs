﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class EventsController : ApiController
    {
        [HttpGet]
        [Route("~/api/Events")]
        public string  GetAllAttenderAndSponsor()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Events> lst = da.GetAllEvents_T();
            return da.Object2Json(lst, "Events", lst.Count);
        }
    }
}
