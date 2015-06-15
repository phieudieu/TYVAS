using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TYVAS_WA.Controllers
{
    public class SponsorEventController : ApiController
    {
        [HttpGet]
        [Route("~/api/SponsorEvent")]
        public string GetAllSponsorEvent()
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<SponsorEvent> lst = da.GetAllSponsorEvent_T();
            return da.Object2Json(lst, "SponsorEvent", lst.Count);
        }

        [HttpGet]
        [Route("~/api/SponsorEvent/{IDSponsor}/{IDEvent}")]
        public string GetSponsorEventBy(int IDSponsor = -1, int IDEvent = -1)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            List<SponsorEvent> lst = da.GetAllSponsorEvent_T(IDSponsor, IDEvent);
            return da.Object2Json(lst, "SponsorEvent", lst.Count);
        }

        [HttpPost]
        [Route("~/api/SponsorEvent")]
        public string InsertSponsorEvent(SponsorEvent obj)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.InsertSponsorEvent(obj).ToString();
        }

        [HttpPost]
        [Route("~/api/SponsorEvent/{IDSponsor}/{IDEvent}")]
        public string  DeleteSponsorEvent(int IDSponsor, int IDEvent)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.DeleteSponsorEvent( IDSponsor, IDEvent ).ToString();
        }

        [HttpPut]
        [Route("~/api/SponsorEvent/{arraycolumn}")]
        public string UpdateSponsorEvent(SponsorEvent obj, string[] arraycolumn)
        {
            MsSqlDataAccess da = new MsSqlDataAccess();
            return da.UpdateSponsorEvent(obj,arraycolumn ).ToString();
        }

    }
}
