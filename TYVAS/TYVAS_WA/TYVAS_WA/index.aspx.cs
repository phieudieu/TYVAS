using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace TYVAS_WA
{
    public partial class index : System.Web.UI.Page
    {
        ILog m_logger = log4net.LogManager.GetLogger(typeof(index));

        protected void Page_Load(object sender, EventArgs e)
        {
            m_logger.Info("Load....");
            MsSqlDataAccess da = new MsSqlDataAccess();
            Attender att = new Attender();

            att.Address = "Quang Trung, Go Vap" + DateTime.Now.ToString();
            att.CreatedDate = DateTime.Now;
            att.CreatedUser = "Rookey" + DateTime.Now.ToString();
            att.Email = "Phieudieu54@gmail.com";
            att.FullName = "Nguyen Thanh Tu" + DateTime.Now.ToString();
            att.LastModifedDate =  DateTime.Now;
            att.LastModifiedUser = "Rookey" + DateTime.Now.ToString();
            da.InsertAttender(att);
            
            //string attstr = da.GetAllAttender();

            Posts p = new Posts();
            p.Actived = 0;
            p.Content = "Tinh Yeu va anh sang ...........................................";
            p.ShortContent  = "Tinh Yeu va anh sang ...........................................";
            p.CreatedBy = "thanh tu" + DateTime.Now.Minute.ToString();
            p.CreatedDate = DateTime.Now;
            p.Image = "/Images/IMG_20140315_173356.jpg";
            p.Keyword = "TYVAS" + DateTime.Now.Minute.ToString();
            p.LastModifedDate = DateTime.Now;
            p.LastModifiedUser = "Rookey" + DateTime.Now.Minute.ToString();
            p.Title = "Chuong trinh DakLak" + DateTime.Now.Minute.ToString();
            p.TopNbr = 1;
            p.ViewNbr = 1;

            da.InsertPosts(p);



        }
    }
}