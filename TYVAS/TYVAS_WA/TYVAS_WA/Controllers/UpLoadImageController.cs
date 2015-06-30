using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Drawing;
using System.Web;
using System.Configuration;

namespace TYVAS_WA.Controllers
{
    public class UpLoadImageController : ApiController
    {
        log4net.ILog m_logger = log4net.LogManager.GetLogger(typeof(UpLoadImageController));

         [HttpPost]
         [Route("~/api/UpLoadFile")]
        public string UpdateFile()
        {
            string result = null;
             HttpContext context = HttpContext.Current;
             try
             {
                 if (context.Request.Files.Count > 0)
                 {
                     string url = Request.RequestUri.Authority;
                     string imagefolder = ConfigurationManager.AppSettings["ImageFolder"];
                     List<Images> lstimg = new List<Images>();
                     HttpFileCollection files = context.Request.Files;
                     for (int i = 0; i < files.Count; i++)
                     {
                         HttpPostedFile file = files[i];
                         string[] arr = file.FileName.Split('.');
                         string filename = arr[0] + "_" + DateTime.Now.ToString("MMddyyHHmmffff") + "." + arr[1];
                         string fname = AppDomain.CurrentDomain.BaseDirectory + "\\" + imagefolder + "\\" + filename; 
                         file.SaveAs(fname);
                         m_logger.Info("fname: " + fname);
                         Images img = new Images();
                         img.ImageName = filename;
                         img.ImageType = "." + arr[1];
                         img.URL = url + "\\" + imagefolder + "\\" + filename;
                         img.FileSize = file.ContentLength;
                         lstimg.Add(img);
                     }
                     context.Response.ContentType = "application/json";
                     MsSqlDataAccess da = new MsSqlDataAccess();                
                     result = da.Object2Json(lstimg, "Images", lstimg.Count);
                 }    
             }
             catch(Exception ex)
             {
                 m_logger.Error(ex.ToString());
             }
             return result;
        }

        [HttpPost]
        [Route("~/api/UpLoadImage")]
        public string UpLoadImage(Images obj)
        {
            string strpath = "";
            try
            {
                MemoryStream memimage = new MemoryStream(obj.ImageData);
                Image img = Image.FromStream(memimage);
                strpath = AppDomain.CurrentDomain.BaseDirectory + "\\TYAS_IMAGES\\" + obj.SaveAsFolder +"\\" + obj.ImageName+"_"+ DateTime.Now.ToString ("MMddyyHHmmffff") + "." + obj.ImageType;
                CreateFolder(AppDomain.CurrentDomain.BaseDirectory + "\\TYAS_IMAGES\\" + obj.SaveAsFolder);
                img.Save(strpath, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception ex )
            {
                m_logger.Error(ex.ToString());
                strpath = "Upload failed";
            }           
            return strpath;
        }              

       [HttpGet ]
       [Route("~/api/GetFolderImage")]
        public List<string> GetFolderImage()
        {
            return GetAllfolder(AppDomain.CurrentDomain.BaseDirectory + "\\TYAS_IMAGES");
        }
              
       [HttpDelete]
       [Route("~/api/Image/{SaveAsFolder}/{ImageName}")]
       public string DeleteImage(string SaveAsFolder, string ImageName)
       {
          string result = "File " + ImageName + " deleted.";
          try
          {
              if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\TYAS_IMAGES\\" + SaveAsFolder + "\\" + ImageName))
              {
                  System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\TYAS_IMAGES\\" + SaveAsFolder + "\\" + ImageName);
              }            
          }
           catch(Exception ex)
          {
              m_logger.Error(ex.ToString());
              result = "File " + ImageName + " can not delete.";
          }
          return result;
       }
       [HttpGet]
       [Route("~/api/GetAllFileInFolder/{foldername}")]
       public string  GetAllFileInFolder(string foldername)
       {
           string json = "";
           try
           {
               MsSqlDataAccess da = new MsSqlDataAccess();
               List<Images> lst = new List<Images>();
               lst = GetAllFile(AppDomain.CurrentDomain.BaseDirectory + "\\TYAS_IMAGES\\" + foldername);
               json = da.Object2Json(lst, "Images", lst.Count);
           }
           catch(Exception ex)
           {
               m_logger.Error(ex.ToString());
           }          
           return json;           
       }

        public List<Images> GetAllFile( string path)
       {
            List<Images> lst = new List<Images>();
            try
            {
                DirectoryInfo d = new DirectoryInfo(path);
                FileInfo[] Files = d.GetFiles();

                Images img = null;
                foreach (FileInfo file in Files)
                {
                    img = new Images();
                    img.ImageName = file.Name;
                    img.ImageType = file.Extension;
                    img.ImageData = (ImageToByteArray(GetByPath(file.FullName)));
                    lst.Add(img);
                }
            }
            catch (Exception ex)
            {
                m_logger.Error(ex.ToString());
            }    
           return lst;
       }

        public List<string> GetAllfolder(string path)
        {
            List<string > lst= new List<string>();
            DirectoryInfo dInfo = new DirectoryInfo( path );
            DirectoryInfo[] subdirs = dInfo.GetDirectories();
            foreach (DirectoryInfo item in subdirs)
            {
                lst.Add(item.Name );
            }
            return lst;
        }

        public Image GetByPath( string path)
        {
            Image img= null ;
            try
            {
                if (File.Exists(path))
                {
                    img = new Bitmap(path);
                }
            }
            catch (Exception ex )
            {
                m_logger.Error(ex.ToString());
            }             
            return img;
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public void CreateFolder(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch(Exception ex)
            {
                m_logger.Error(ex.ToString());
            }            
        }
       
    }
}
