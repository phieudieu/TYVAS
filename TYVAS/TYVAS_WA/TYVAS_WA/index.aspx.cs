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

         att.Address = "Quang Trung, Go Vap Attender" + DateTime.Now.ToString();
            att.CreatedDate = DateTime.Now;
            att.CreatedUser = "Rookey Attender" + DateTime.Now.ToString();
            att.Email = "Phieudieu54@gmail.com";
            att.FullName = "Nguyen Thanh Tu Attender" + DateTime.Now.ToString();
            att.LastModifedDate =  DateTime.Now;
            att.LastModifiedUser = "Rookey Attender" + DateTime.Now.ToString();
            string newid = "ID";
            da.InsertAttender(att, newid);

            Sponsor sp = new Sponsor();

            sp.Address = "Quang Trung, Go Vap Sponsor" + DateTime.Now.ToString();
            sp.CreatedDate = DateTime.Now;
            sp.CreatedUser = "Rookey Sponsor" + DateTime.Now.ToString();
            sp.Email = "Phieudieu54@gmail.com";
            sp.FullName = "Nguyen Thanh Tu Sponsor" + DateTime.Now.ToString();
            sp.LastModifedDate = DateTime.Now;
            sp.LastModifiedUser = "Rookey Sponsor" + DateTime.Now.ToString();
            da.InsertSponsor(sp);

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


            Banner bn = new Banner();
            bn.Description = "Top" + DateTime.Now.Minute.ToString ();
            bn.ImageName = "BannerTop";
            bn.Path = "/BannerTop.png";
            da.InsertBanner(bn);

            Comment cm = new Comment();
            cm.Actived = 1;
            cm.ApprovedBy = "TT";
            cm.ApprovedDate = DateTime.Now;
            cm.CMDate = DateTime.Now;
            cm.PID = DateTime.Now.Millisecond ;
            cm.Reason = "";
            cm.UserID = DateTime.Now.ToString("MMddyyyyHHmmss");
            da.InsertComment(cm);


            Events ev = new Events();
            ev.Address = "NVL Go Vap";
            ev.Amount = 1000000;
            ev.Banner = "/Banner.png";
            ev.CreatedDate = DateTime.Now;
            ev.CreatedUser = "TT";
            ev.Description = "Chuyến đi tới...";
            ev.EndDate = DateTime.Now;
            ev.FeeJoin = 200000;
            ev.Images = "/Image.png";
            ev.LastModifedDate = DateTime.Now;
            ev.LastModifiedUser = "TT";
            ev.Reference = "";
            ev.StartDate = DateTime.Now;
            ev.Title = "Title";
            ev.Status = 1;
            da.InsertEvents(ev);

            Sharing sh = new Sharing();
            sh.Author = "TT";
            sh.CreatedDate = DateTime.Now;
            sh.Description = "Share posts";
            sh.LastModifedDate = DateTime.Now;
            sh.LastModifiedUser = "TT";
            sh.Title = "share";
            da.InsertSharing(sh);

            SponsorEvent sv = new SponsorEvent();
            sv.CreatedDate = DateTime.Now;
            sv.CreatedUser = "TT";
            sv.Donate = 100;
            sv.IDEvent = 1;
            sv.IDSponsor = 1;
            sv.LastModifedDate = DateTime.Now;
            sv.LastModifiedUser = "TT";
            da.InsertSponsorEvent(sv);

            Users u = new Users();
            u.Actived = 1;
            u.BirthDay = DateTime.Now;
            u.CreatedDate = DateTime.Now;
            u.Email = DateTime.Now.ToString("MMddyyyMMhh") + "tyas@gmail.com";
            u.FirstName = DateTime.Now.ToString("MMddyyy");
            u.PassWord="password" ;
            u.LastUpdate = DateTime.Now;
            u.LMName  = DateTime.Now.ToString("HHmmss");
            u.Sex = 1;
            u.Status = 1;
            u.UserID = DateTime.Now.ToString("ffff");
            u.UserName = DateTime.Now.ToString("MMddyyffff");
            u.Image = "/Image.png";
            da.InsertUsers(u);
        }
    }
}