using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

public class JsonUtils
{
    log4net.ILog m_logger = log4net.LogManager.GetLogger(typeof(JsonUtils));
    public JsonUtils()
    {

    }
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
}