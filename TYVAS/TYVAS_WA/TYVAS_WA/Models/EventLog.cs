using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EventLog
/// </summary>
public class EventLog
{
    private int m_ID;
    private string m_Category;
    private string m_UserID;
    private DateTime m_DateTimeStamp;
    private string m_FromData;
    private string m_ToData;
    public EventLog()
    {
        m_ID = 0;
        m_Category = String.Empty;
        m_UserID = String.Empty;
        m_DateTimeStamp = DateTime.MinValue;
        m_FromData = String.Empty;
        m_ToData = String.Empty;
    }
    public int ID
    {
        get { return m_ID; }
        set { m_ID = value; }
    }
    public string Category
    {
        get { return m_Category; }
        set { m_Category = value; }
    }
    public string UserID
    {
        get { return m_UserID; }
        set { m_UserID = value; }
    }
    public DateTime DateTimeStamp
    {
        get { return m_DateTimeStamp; }
        set { m_DateTimeStamp = value; }
    }
    public string FromData
    {
        get { return m_FromData; }
        set { m_FromData = value; }
    }
    public string ToData
    {
        get { return m_ToData; }
        set { m_ToData = value; }
    }

}