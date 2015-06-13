using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using System.Reflection;
using System.Configuration;
using System.Data.SqlClient;
 

public static class ConvertData2Object
{
    //log4net.ILog m_logger = log4net.LogManager.GetLogger(typeof(MsSqlDataAccess));

    /// <summary>
    /// Create item from datarow
    /// </summary>
    /// <typeparam name="T">Object return</typeparam>
    /// <param name="row">Object</param>
    /// <param name="properties">List properties of Object</param>
    /// <returns>Object</returns>
    private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
    {
        log4net.ILog m_logger = log4net.LogManager.GetLogger(typeof(MsSqlDataAccess));
        T item = new T();
        try
        {
            foreach (var property in properties)
            {
                property.SetValue(item, row[property.Name], null);
            }
        }
        catch(Exception ex)
        {
            m_logger.Error(ex.ToString());
        }       
        return item;
    }

    /// <summary>
    /// List object
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    /// <param name="table">Table</param>
    /// <returns>Object lst</returns>
    public static List<T> DataTableToList<T>(this DataTable table) where T : new()
    {
        log4net.ILog m_logger = log4net.LogManager.GetLogger(typeof(MsSqlDataAccess));
        IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
        List<T> result = new List<T>();
        try
        {
            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return result;
    }
}

/// <summary>
/// Summary description for MsSqlDataAccess
/// </summary>
public  class MsSqlDataAccess
{
    log4net.ILog m_logger = log4net.LogManager.GetLogger(typeof(MsSqlDataAccess));
    AccessData m_da = null;
     
    public MsSqlDataAccess()
    {
        m_da = new AccessData();
    }

    #region Json utils

    public string Object2Json(object obj, string objectname, int itemcount)
    {
        string json = "";
        Dictionary<string, object> dic = new Dictionary<string, object>();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        try
        {
            dic.Add(objectname, obj);
            dic.Add("ItemCount", itemcount.ToString());
            json = serializer.Serialize(dic);
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
            json = ex.ToString();
        }
        return json;
    }

    public void AddObject2Dictionary(ref Dictionary<string, object> dic, object ojb, string objname, int itemcount)
    {
        try
        {
            dic.Add(objname, ojb);
            dic.Add("ItemCount", itemcount);
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
    }

    public string Dictionary2Json(Dictionary<string, object> dic)
    {
        string json = "";
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        try
        {
            json = serializer.Serialize(dic);
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
            json = ex.ToString();
        }
        return json;
    }

    #endregion

    #region GetAll Object List

    public List<Sponsor> GetAllSponsor_T( int id =-1)
    {
        string where = "";
        if (id>-1 )
        {
            where = " where id = " + id;
        }
        List<Sponsor> objList = new List<Sponsor>();
        string sqltext = "select * from Sponsor" + where ;
        try
        {
            objList = ConvertData2Object.DataTableToList<Sponsor>(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return objList;
    }

    public List<Attender> GetAllAttender_T(int id = -1)
    {
        string where = "";
        if (id > -1)
        {
            where = " where id = " + id;
        }
        List<Attender> objList = new List<Attender>();
        string sqltext = "select * from attender" + where;
        try
        {
            objList = ConvertData2Object.DataTableToList<Attender>(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return objList;
    }

    public List<AttenderEvent> GetAllAttenderEvent_T(int IDAttender = -1, int IDEvent = -1)
    {
        string where = "";
        if (IDAttender > -1 && IDEvent > -1)
        {
            where = " where IDAttender = " + IDAttender + " and IDEvent = " + IDEvent;
        }
        List<AttenderEvent> objList = new List<AttenderEvent>();
        string sqltext = "select * from AttenderEvent" + where;
        try
        {
            objList = ConvertData2Object.DataTableToList<AttenderEvent>(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return objList;
    }

    public List<Banner> GetAllBanner_T(int id = -1)
    {
        string where = "";
        if (id > -1)
        {
            where = " where id = " + id;
        }
        List<Banner> objList = new List<Banner>();
        string sqltext = "select * from Banner" + where;
        try
        {
            objList = ConvertData2Object.DataTableToList<Banner>(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return objList;
    }

    public List<Category> GetAllCategory_T(int id = -1)
    {
        string where = "";
        if (id > -1)
        {
            where = " where id = " + id;
        }
        List<Category> objList = new List<Category>();
        string sqltext = "select * from Category" + where;
        try
        {
            objList = ConvertData2Object.DataTableToList<Category>(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return objList;
    }

    public List<Comment> GetAllComment_T(int pid = -1)
    {
        string where = "";
        if (pid > -1)
        {
            where = " where pid = " + pid;
        }
        List<Comment> objList = new List<Comment>();
        string sqltext = "select * from Comment" + where;
        try
        {
            objList = ConvertData2Object.DataTableToList<Comment>(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return objList;
    }

    public List<Doccument> GetAllDoccument_T(int id = -1)
    {
        string where = "";
        if (id > -1)
        {
            where = " where id = " + id;
        }
        List<Doccument> objList = new List<Doccument>();
        string sqltext = "select * from Doccument" + where;
        try
        {
            objList = ConvertData2Object.DataTableToList<Doccument>(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return objList;
    }

    public List<Events> GetAllEvents_T(int id = -1)
    {
        string where = "";
        if (id > -1)
        {
            where = " where id = " + id;
        }
        List<Events> objList = new List<Events>();
        string sqltext = "select * from Events" + where;
        try
        {
            objList = ConvertData2Object.DataTableToList<Events>(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return objList;
    }

    public List<Sharing> GetAllSharing_T(int id = -1)
    {
        string where = "";
        if (id > -1)
        {
            where = " where id = " + id;
        }
        List<Sharing> objList = new List<Sharing>();
        string sqltext = "select * from Sharing" + where;
        try
        {
            objList = ConvertData2Object.DataTableToList<Sharing>(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return objList;
    }

    public List<SponsorEvent> GetAllSponsorEvent_T(int IDSponsor = -1, int IDEvent = -1)
    {
        string where = "";
        if (IDSponsor > -1 && IDEvent > -1)
        {
            where = " where IDSponsor = " + IDSponsor + " and IDEvent = " + IDEvent;
        }
        List<SponsorEvent> objList = new List<SponsorEvent>();
        string sqltext = "select * from SponsorEvent" + where;
        try
        {
            objList = ConvertData2Object.DataTableToList<SponsorEvent>(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return objList;
    }

    public List<Posts> GetAllPosts_T(int pid = -1)
    {
        string where = "";
        if (pid > -1)
        {
            where = " where pid = " + pid;
        }
        List<Posts> objList = new List<Posts>();
        string sqltext = "select * from Posts" + where;
        try
        {
            objList = ConvertData2Object.DataTableToList<Posts>(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return objList;
    }

    public List<TYASInfo> GetAllTYASInfo_T(int id = -1)
    {
        string where = "";
        if (id > -1)
        {
            where = " where id = " + id;
        }
        List<TYASInfo> objList = new List<TYASInfo>();
        string sqltext = "select * from TYASInfo" + where;
        try
        {
            objList = ConvertData2Object.DataTableToList<TYASInfo>(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return objList;
    }

    public List<Users> GetAllUser_T(string  UserID = "")
    {
        string where = "";
        if (!UserID.Equals( "") )
        {
            where = " where UserID = " + UserID;
        }
        List<Users> objList = new List<Users>();
        string sqltext = "select * from Users" + where;
        try
        {
            objList = ConvertData2Object.DataTableToList<Users>(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return objList;
    }

    #endregion

    #region Get All Object

    public static string ReplaceWith(string text)
    {
        string result =text;
        result = result.Replace ("<string xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">","");
        result = result.Replace("</string>", "");    
        return result;
    }

    public static string DataTableToJSON(DataTable table)
    {
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        foreach (DataRow row in table.Rows)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            foreach (DataColumn col in table.Columns)
            {
                dict[col.ColumnName] = row[col];
            }
            list.Add(dict);
        }
       
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        return  ReplaceWith(serializer.Serialize(list));
    }    

    public string GetAllAttender()
    {
        string json = "";
        string sqltext = "select * from attender";
        try
        {
            json = DataTableToJSON(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return json;
    }

    public string GetAllAttenderAndSponsor()
    {
        string json = "";
        string sqltext = "select * from AttenderAndSponsor";
        try
        {
            json = DataTableToJSON(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return json;
    }

    public string GetAllAttenderEvent()
    {
        string json = "";
        string sqltext = "select * from AttenderEvent";
        try
        {
            json = DataTableToJSON(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return json;
    }

    public string GetAllBanner()
    {
        string json = "";
        string sqltext = "select * from Banner";
        try
        {
            json = DataTableToJSON(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return json;
    }

    public string GetAllCategory()
    {
        string json = "";
        string sqltext = "select * from Category";
        try
        {
            json = DataTableToJSON(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return json;
    }

    public string GetAllComment()
    {
        string json = "";
        string sqltext = "select * from Comment";
        try
        {
            json = DataTableToJSON(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return json;
    }

    public string GetAllDoccument()
    {
        string json = "";
        string sqltext = "select * from Doccument";
        try
        {
            json = DataTableToJSON(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return json;
    }

    public string GetAllEvents()
    {
        string json = "";
        string sqltext = "select * from Events";
        try
        {
            json = DataTableToJSON(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return json;
    }

    public string GetAllPosts()
    {
        string json = "";
        string sqltext = "select * from Posts";
        try
        {
            json = DataTableToJSON(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return json;
    }

    public string GetAllSharing()
    {
        string json = "";
        string sqltext = "select * from Sharing";
        try
        {
            json = DataTableToJSON(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return json;
    }

    public string GetAllSponsorEvent()
    {
        string json = "";
        string sqltext = "select * from SponsorEvent";
        try
        {
            json = DataTableToJSON(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return json;
    }

    public string GetAllUser()
    {
        string json = "";
        string sqltext = "select * from User";
        try
        {
            json = DataTableToJSON(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return json;
    }

    public string GetAllTYASInfo()
    {
        string json = "";
        string sqltext = "select * from TYASInfo";
        try
        {
            json = DataTableToJSON(m_da.GetDataTable(sqltext));
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return json;
    }

    #endregion

    #region Get data by

    #endregion

    #region Insert Entity

    public bool InsertAttender(Attender obj)
    {
        string[] col = { "FullName", "Email", "Phone", "Address", "Type", "CreatedDate", "LastModifedDate", "CreatedUser", "LastModifiedUser" };
        return m_da.InsertRow("Attender", obj, col);
    }

    public bool InsertSponsor(Sponsor obj)
    {
        string[] col = { "FullName", "Email", "Phone", "Address", "Type", "CreatedDate", "LastModifedDate", "CreatedUser", "LastModifiedUser" };
        return m_da.InsertRow("Sponsor", obj, col);
    }

    public bool InsertAttenderEvent(AttenderEvent obj)
    {
        string[] col = { "IDAttender", "IDEvent", "CompletedFee", "CreatedDate", "LastModifedDate", "CreatedUser", "LastModifiedUser" };
        return m_da.InsertRow("AttenderEvent", obj, col);
    }

    public bool InsertBanner(Banner obj)
    {
        string[] col = { "Description", "ImageName", "Path" };
        return m_da.InsertRow("Banner", obj, col);
    }

    public bool InsertCategory(Category obj)
    {
        string[] col = { "Name", "Description", "Link" };
        return m_da.InsertRow("Category", obj, col);
    }

    public bool InsertComment(Comment obj)
    {
        string[] col = { "PID", "UserID", "Content", "CMDate", "ApprovedBy", "ApprovedDate", "Actived", "Reason" };
        return m_da.InsertRow("Comment", obj, col);
    }
    public bool InsertDoccument(Doccument obj)
    {
        string[] col = { "Title", "Document", "Path" };
        return m_da.InsertRow("Doccument", obj, col);
    }
    public bool InsertEventLog(EventLog obj)
    {
        string[] col = { "Category", "UserID", "DateTimeStamp", "FromData", "ToData" };
        return m_da.InsertRow("EventLog", obj, col);
    }
    public bool InsertEvents(Events obj)
    {
        string[] col = { "Title", "Description", "Address", "Reference", "StartDate", "EndDate", "Images", "Banner", "Status", "Amount", "FeeJoin", "CreatedDate", "LastModifedDate", "CreatedUser", "LastModifiedUser" };
        return m_da.InsertRow("Events", obj, col);
    }
    public bool InsertPosts(Posts obj)
    {
        string[] col = { "Title", "Keyword", "Content", "ShortContent", "CreatedDate", "CreatedBy", "ViewNbr", "Image", "Actived", "LastModifedDate", "LastModifiedUser", "TopNbr" };
        return m_da.InsertRow("Posts", obj, col);
    }
    public bool InsertSponsorEvent(SponsorEvent obj)
    {
        string[] col = { "IDSponsor", "IDEvent", "Donate", "CreatedDate", "LastModifedDate", "CreatedUser", "LastModifiedUser" };
        return m_da.InsertRow("SponsorEvent", obj, col);
    }
    public bool InsertSharing(Sharing obj)
    {
        string[] col = { "Title", "Description", "Author", "CreatedDate", "LastModifedDate", "LastModifiedUser" };
        return m_da.InsertRow("Sharing", obj, col);
    }
    public bool InsertUser(Users obj)
    {
        string[] col = { "UserID", "FirstName", "LMName", "Sex", "Email", "BirthDay", "UserName", "PassWord", "Image", "CreatedDate", "LastUpdate", "Actived", "Status", "IDReset" };
        return m_da.InsertRow("Users", obj, col);
    }
    public bool InsertUser(TYASInfo obj)
    {
        string[] col = { "Name", "Content" };
        return m_da.InsertRow("TYASInfo", obj, col);
    }
    #endregion

    #region Update Entity

    public bool UpdateAttender(Attender obj)
    {
        string[] col = { "FullName", "Email", "Phone", "Address", "Type", "CreatedDate", "LastModifedDate", "CreatedUser", "LastModifiedUser" };
        string where = string.Format(" ID = {0}", obj.ID);
        return m_da.UpdateRow("Attender", obj, col, where);
    }
    public bool UpdateAttenderAndSponsor(Sponsor obj)
    {
        string[] col = { "FullName", "Email", "Phone", "Address", "Type", "CreatedDate", "LastModifedDate", "CreatedUser", "LastModifiedUser" };
        string where = string.Format(" ID = {0}", obj.ID);
        return m_da.UpdateRow("Sponsor", obj, col, where);
    }

    public bool UpdateAttenderEvent(AttenderEvent obj)
    {
        string[] col = { "IDAttender", "IDEvent", "CompletedFee", "CreatedDate", "LastModifedDate", "CreatedUser", "LastModifiedUser" };
        string where = string.Format(" IDAttender = '{0}' and  IDEvent= {1}", obj.IDAttender, obj.IDEvent);
        return m_da.UpdateRow("AttenderEvent", obj, col, where);
    }

    public bool UpdateBanner(Banner obj)
    {
        string[] col = { "Description", "ImageName", "Path" };
        string where = string.Format(" ID = {0}", obj.ID);
        return m_da.UpdateRow("Banner", obj, col, where);
    }

    public bool UpdateCategory(Category obj)
    {
        string[] col = { "Name", "Description", "Link" };
        string where = string.Format(" ID = {0}", obj.ID);
        return m_da.UpdateRow("Category", obj, col, where);
    }

    public bool UpdateComment(Comment obj)
    {
        string[] col = { "PID", "UserID", "Content", "CMDate", "ApprovedBy", "ApprovedDate", "Actived", "Reason" };
        string where = string.Format(" PID = {0}", obj.PID);
        return m_da.UpdateRow("Comment", obj, col, where);
    }
    public bool UpdateDoccument(Doccument obj)
    {
        string[] col = { "Title", "Document", "Path" };
        string where = string.Format(" ID = {0}", obj.ID);
        return m_da.UpdateRow("Doccument", obj, col, where);
    }
    public bool UpdateEventLog(EventLog obj)
    {
        string[] col = { "Category", "UserID", "DateTimeStamp", "FromData", "ToData" };
        string where = string.Format(" ID = {0}", obj.ID);
        return m_da.UpdateRow("EventLog", obj, col, where);
    }
    public bool UpdateEvents(Events obj)
    {
        string[] col = { "Title", "Description", "Address", "Reference", "StartDate", "EndDate", "Images", "Banner", "Status", "Amount", "FeeJoin", "CreatedDate", "LastModifedDate", "CreatedUser", "LastModifiedUser" };
        string where = string.Format(" ID = {0}", obj.ID);
        return m_da.UpdateRow("Events", obj, col, where);
    }
    public bool UpdatePosts(Posts obj)
    {
        string[] col = { "Title", "Keyword", "Content", "ShortContent", "CreatedDate", "CreatedBy", "View", "Image", "Actived", "LastModifedDate", "LastModifiedUser", "Top" };
        string where = string.Format(" ID = {0}", obj.PID);
        return m_da.UpdateRow("Posts", obj, col, where);
    }
    public bool UpdateSponsorEvent(SponsorEvent obj)
    {
        string[] col = { "IDSponsor", "IDEvent", "Donate", "CreatedDate", "LastModifedDate", "CreatedUser", "LastModifiedUser" };
        string where = string.Format(" IDSponsor = '{0}' and  IDEvent= '{1}'", obj.IDSponsor, obj.IDEvent);
        return m_da.UpdateRow("SponsorEvent", obj, col, where);
    }
    public bool UpdateSharing(Sharing obj)
    {
        string[] col = { "Title", "Description", "Author", "CreatedDate", "LastModifedDate", "LastModifiedUser" };
        string where = string.Format(" ID = {0}", obj.ID);
        return m_da.UpdateRow("Sharing", obj, col, where);
    }
    public bool UpdateUser(Users obj)
    {
        string[] col = { "UserID", "FirstName", "LMName", "Sex", "Email", "BirthDay", "UserName", "PassWord", "Image", "CreatedDate", "LastUpdate", "Actived", "Status", "IDReset" };
        string where = string.Format(" UserID = '{0}'", obj.UserID);
        return m_da.UpdateRow("Users", obj, col, where);
    }
    public bool UpdateUser(TYASInfo obj)
    {
        string[] col = { "Name", "Content" };
        string where = string.Format(" ID = {0}", obj.ID);
        return m_da.UpdateRow("TYASInfo", obj, col, where);
    }
    #endregion

     

}
