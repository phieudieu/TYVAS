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
        public string GetAllEvents()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Events> lst = da.GetAllEvents_T();
            return da.Object2Json(lst, "Events", lst.Count);
        }

        [HttpGet]
        [Route("~/api/Events/{id}")]
        public string GetEventsBy(int id = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Events> lst = da.GetAllEvents_T(id);
            return da.Object2Json(lst, "Events", lst.Count);
        }

        [HttpGet]
        [Route("~/api/Paging/Events/{PageNumber}/{RowspPage}")]
        public string GetAllEventsPaging(int PageNumber, int RowspPage)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<Events> lst = da.GetAllEventsPaging_T(PageNumber, RowspPage);
            return da.Object2Json(lst, "Events", lst.Count, da.CountDataFromTable("Events"));
        }

        //[HttpPost]
        //[Route("~/api/Events")]
        //public HttpResponseMessage InsertEvents()
        //{
        //    HttpContent requestContent = Request.Content;
        //    Events evt = null;
        //    string jsonContent = requestContent.ReadAsStringAsync().Result;
        //    evt= ConvertData2Object.Json2Object<Events>(jsonContent);
        //    return null;
        //}

        [HttpPost]
        [Route("~/api/Events")]
        public string InsertEvents([FromBody]Events obj)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.InsertEvents(obj).ToString();
        }

        [HttpDelete ]
        [Route("~/api/Events/{id}")]
        public string DeleteEvents(int id)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.DeleteEvents(id).ToString();
        }

        [HttpPost]
        [Route("~/api/Events/{arraycolumn}")]
        public string UpdateEvents(Events obj, string[] arraycolumn)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.UpdateEvents(obj, arraycolumn).ToString();
        }

    }
}
