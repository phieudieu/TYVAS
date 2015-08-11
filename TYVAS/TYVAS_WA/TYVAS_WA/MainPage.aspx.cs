using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TYVAS_WA
{
    public partial class MainPage : System.Web.UI.Page
    {
        public class Global : System.Web.HttpApplication
        {
            protected void Application_BeginRequest(object sender, EventArgs e)
            {
                if (Request.Url.AbsolutePath.EndsWith("/"))
                {
                    Server.Transfer(Request.Url.AbsolutePath + "index.aspx");
                }
            }
        }
    }
}