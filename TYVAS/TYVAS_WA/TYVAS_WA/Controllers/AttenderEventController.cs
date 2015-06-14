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
        
        [HttpGet]
        [Route("~/api/AttenderEvent")]
        public string GetAllAttenderEvent()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<AttenderEvent> lst = da.GetAllAttenderEvent_T();
            return da.Object2Json(lst, "AttenderEvent", lst.Count);
        }


        [HttpGet]
        [Route("~/api/AttenderEvent/{IDAttender}/{IDEvent}")]
        public string GetAttenderEventBy(int IDAttender = -1, int IDEvent = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<AttenderEvent> lst = da.GetAllAttenderEvent_T(IDAttender, IDEvent);
            return da.Object2Json(lst, "AttenderEvent", lst.Count);
        }

        [HttpPost ]
        [Route("~/api/AttenderEvent")]
        public string InsertAttenderEvent( AttenderEvent obj)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.InsertAttenderEvent(obj).ToString ();
        }
        [HttpDelete ]
        [Route("~/api/AttenderEvent/{IDAttender}/{IDEvent}")]
        public string DeleteAttenderEvent(int IDAttender, int  IDEvent)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.DeleteAttenderEvent(IDAttender, IDEvent).ToString();
        }

    }
}
