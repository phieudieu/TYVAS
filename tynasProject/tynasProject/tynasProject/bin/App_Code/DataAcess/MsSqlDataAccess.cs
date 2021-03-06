﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using System.Reflection;

/// <summary>
/// Summary description for MsSqlDataAccess
/// </summary>
public class MsSqlDataAccess
{
    log4net.ILog m_logger = log4net.LogManager.GetLogger(typeof(MsSqlDataAccess));
    AccessData m_da = null;

    public MsSqlDataAccess()
    {
        m_da = new AccessData();
    }

    #region function

    ///// <summary>
    ///// Create item from datarow
    ///// </summary>
    ///// <typeparam name="T">Object return</typeparam>
    ///// <param name="row">Object</param>
    ///// <param name="properties">List properties of Object</param>
    ///// <returns>Object</returns>
    //private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
    //{
    //    T item = new T();
    //    foreach (var property in properties)
    //    {
    //        property.SetValue(item, row[property.Name], null);
    //    }
    //    return item;
    //}

    ///// <summary>
    ///// List object
    ///// </summary>
    ///// <typeparam name="T">Object</typeparam>
    ///// <param name="table">Table</param>
    ///// <returns>Object lst</returns>
    //public static IList<T> DataTableToList<T>(this DataTable table) where T : new()
    //{
    //    IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
    //    IList<T> result = new List<T>();

    //    foreach (var row in table.Rows)
    //    {
    //        var item = CreateItemFromRow<T>((DataRow)row, properties);
    //        result.Add(item);
    //    }

    //    return result;
    //}

    #endregion

    #region GetAll Object

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
        return serializer.Serialize(list);
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

    public bool InsertAttenderAndSponsor(AttenderAndSponsor obj)
    {
        string[] col = { "FullName", "Email", "Phone", "Address", "Type", "CreatedDate", "LastModifedDate", "CreatedUser", "LastModifiedUser" };
        return m_da.InsertRow("AttenderAndSponsor", obj, col);
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
        string[] col = { "Title", "Keyword", "Content", "ShortContent", "CreatedDate", "CreatedBy", "View", "Image", "Actived", "LastModifedDate", "LastModifiedUser", "Top" };
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
    public bool InsertUser(User obj)
    {
        string[] col = { "UserID", "FirstName", "LMName", "Sex", "Email", "BirthDay", "UserName", "PassWord", "Image", "CreatedDate", "LastUpdate", "Actived", "Status", "IDReset" };
        return m_da.InsertRow("User", obj, col);
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
    public bool UpdateAttenderAndSponsor(AttenderAndSponsor obj)
    {
        string[] col = { "FullName", "Email", "Phone", "Address", "Type", "CreatedDate", "LastModifedDate", "CreatedUser", "LastModifiedUser" };
        string where = string.Format(" ID = {0}", obj.ID);
        return m_da.UpdateRow("AttenderAndSponsor", obj, col, where);
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
    public bool UpdateUser(User obj)
    {
        string[] col = { "UserID", "FirstName", "LMName", "Sex", "Email", "BirthDay", "UserName", "PassWord", "Image", "CreatedDate", "LastUpdate", "Actived", "Status", "IDReset" };
        string where = string.Format(" UserID = '{0}'", obj.UserID);
        return m_da.UpdateRow("User", obj, col, where);
    }
    public bool UpdateUser(TYASInfo obj)
    {
        string[] col = { "Name", "Content" };
        string where = string.Format(" ID = {0}", obj.ID);
        return m_da.UpdateRow("TYASInfo", obj, col, where);
    }
    #endregion

}
