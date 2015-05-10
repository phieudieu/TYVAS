using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using log4net.Config;

public partial class _Default : Page
{
    ILog m_logger = log4net.LogManager.GetLogger(typeof(_Default));

    protected void Page_Load(object sender, EventArgs e)
    {
        m_logger.Info("Webstart...............");

        Attender att = new Attender();
      
    }
}