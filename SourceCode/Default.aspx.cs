using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using log4net.Config;
using System.Web.Configuration  ;
using System.Configuration;

public partial class _Default : Page
{
    ILog m_logger = log4net.LogManager.GetLogger(typeof(_Default));

    protected void Page_Load(object sender, EventArgs e)
    {
        m_logger.Info("Webstart...............");
        //Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
        //config.AppSettings.Settings.Remove("MyVariable");
        //config.AppSettings.Settings.Add("MyVariable", "MyValue");
        //config.Save();
        Attender att = new Attender();
        att.Address = "Nguyen Van Luong1";
        att.CreatedDate = DateTime.Now;
        att.CreatedUser = "Rookey";
        att.Email = "Phieudieu54@gmail.com";
        att.FullName = "";
        MsSqlDataAccess da = new MsSqlDataAccess();
        da.InsertAttender(att);

        string attstr = da.GetAllAttender();

        AttenderAndSponsor attsp = new AttenderAndSponsor();
        attsp.Address = "";
        attsp.CreatedDate = DateTime.Now;
        attsp.CreatedUser = "Rookey";
        attsp.Email = "";
        
      
    }
}