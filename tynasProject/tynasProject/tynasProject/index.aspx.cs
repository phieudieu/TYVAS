using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using log4net.Config ;
using System.Web.Configuration  ;
using System.Configuration;


namespace tynasProject
{
    public partial class index : System.Web.UI.Page
    {
        ILog m_logger = log4net.LogManager.GetLogger(typeof(index));
        
        protected void Page_Load(object sender, EventArgs e)
        {
            m_logger.Info("Load....");
            MsSqlDataAccess da = new MsSqlDataAccess();
            Attender att = new Attender();

            att.Address = "Quang Trung, Go Vap";
            att.CreatedDate = DateTime.Now;
            att.CreatedUser = "Rookey";
            att.Email = "Phieudieu54@gmail.com";
            att.FullName = "Nguyen Thanh Tu";
            da.InsertAttender(att);

            string attstr = da.GetAllAttender();
            
        }
    }
}