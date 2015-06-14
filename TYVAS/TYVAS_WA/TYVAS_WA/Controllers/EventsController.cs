using System;
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

        [HttpPost]
        [Route("~/api/Events")]
        public string InsertEvents(Events obj)
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

    }
}
