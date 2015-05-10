using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using log4net;
using log4net.Config;
using System.Data;

using System.Reflection;

/// <summary>
/// Summary description for MsSqlDataAccess
/// </summary>
public class MsSqlDataAccess
{
    ILog m_logger = log4net.LogManager.GetLogger(typeof(MsSqlDataAccess));
    AccessData m_da = new AccessData();

	public MsSqlDataAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region function

    /// <summary>
    /// Create item from datarow
    /// </summary>
    /// <typeparam name="T">Object return</typeparam>
    /// <param name="row">Object</param>
    /// <param name="properties">List properties of Object</param>
    /// <returns>Object</returns>
    private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
    {
        T item = new T();
        foreach (var property in properties)
        {
            property.SetValue(item, row[property.Name], null);
        }
        return item;
    }

    /// <summary>
    /// List object
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    /// <param name="table">Table</param>
    /// <returns>Object lst</returns>
    public static IList<T> DataTableToList<T>(this DataTable table) where T : new()
    {
        IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
        IList<T> result = new List<T>();

        foreach (var row in table.Rows)
        {
            var item = CreateItemFromRow<T>((DataRow)row, properties);
            result.Add(item);
        }

        return result;
    }

#endregion

    #region GetAll Object

    public string GetAllAttender()
    {
        string json = "";
        string sqltext = "select * from attender";
        try
        {
            //List<Attender> attlst = new List<Attender>();
            json = new JavaScriptSerializer().Serialize(m_da.GetDataTable(sqltext));
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
            json = new JavaScriptSerializer().Serialize(m_da.GetDataTable(sqltext));
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
            json = new JavaScriptSerializer().Serialize(m_da.GetDataTable(sqltext));
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
            json = new JavaScriptSerializer().Serialize(m_da.GetDataTable(sqltext));
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
            json = new JavaScriptSerializer().Serialize(m_da.GetDataTable(sqltext));
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
            json = new JavaScriptSerializer().Serialize(m_da.GetDataTable(sqltext));
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
            json = new JavaScriptSerializer().Serialize(m_da.GetDataTable(sqltext));
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
            json = new JavaScriptSerializer().Serialize(m_da.GetDataTable(sqltext));
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
            json = new JavaScriptSerializer().Serialize(m_da.GetDataTable(sqltext));
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
            json = new JavaScriptSerializer().Serialize(m_da.GetDataTable(sqltext));
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
            json = new JavaScriptSerializer().Serialize(m_da.GetDataTable(sqltext));
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
            json = new JavaScriptSerializer().Serialize(m_da.GetDataTable(sqltext));
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
    
    #region Insert

    public  bool InsertAttender(Attender obj)
    {        
        return  m_da.InsertRow( "Attender", obj);               
    }

    public bool InsertAttenderAndSponsor(AttenderAndSponsor obj)
    {
        return m_da.InsertRow("AttenderAndSponsor", obj);
    }

    public bool InsertAttenderEvent(AttenderEvent obj)
    {
        return m_da.InsertRow("AttenderEvent", obj);
    }

    public bool InsertBanner(Banner obj)
    {
        return m_da.InsertRow("Banner", obj);
    }

    public bool InsertCategory(Category obj)
    {
        return m_da.InsertRow("Category", obj);
    }

    public bool InsertComment(Comment obj)
    {
        return m_da.InsertRow("Comment", obj);
    }
    public bool InsertDoccument(Doccument obj)
    {
        return m_da.InsertRow("Doccument", obj);
    }
    public bool InsertEventLog(EventLog obj)
    {
        return m_da.InsertRow("EventLog", obj);
    }
    public bool InsertEvents(Events obj)
    {
        return m_da.InsertRow("Events", obj);
    }
    public bool InsertPosts(Posts obj)
    {
        return m_da.InsertRow("Posts", obj);
    }
    public bool InsertSponsorEvent(SponsorEvent obj)
    {
        return m_da.InsertRow("SponsorEvent", obj);
    }
    public bool InsertSharing(Sharing obj)
    {
        return m_da.InsertRow("Sharing", obj);
    }
    public bool InsertUser(User obj)
    {
        return m_da.InsertRow("User", obj);
    }
    #endregion

    #region Update

    public bool UpdateAttender(Attender obj)
    {
        string[] col = { };
        return m_da.UpdateRow("Attender",  obj, col );
    }

    #endregion

}

