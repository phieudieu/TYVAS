using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Comment
/// </summary>
public class Comment
{
    private int m_PID;
    private string m_UserID;
    private string m_Content;
    private DateTime m_CMDate;
    private string m_ApprovedBy;
    private DateTime m_ApprovedDate;
    private int m_Actived;
    private string m_Reason;
    public Comment()
    {
        m_PID = 0;
        m_UserID = String.Empty;
        m_Content = String.Empty;
        m_CMDate = DateTime.MinValue;
        m_ApprovedBy = String.Empty;
        m_ApprovedDate = DateTime.MinValue;
        m_Actived = 0;
        m_Reason = String.Empty;
    }
    public int PID
    {
        get { return m_PID; }
        set { m_PID = value; }
    }
    public string UserID
    {
        get { return m_UserID; }
        set { m_UserID = value; }
    }
    public string Content
    {
        get { return m_Content; }
        set { m_Content = value; }
    }
    public DateTime CMDate
    {
        get { return m_CMDate; }
        set { m_CMDate = value; }
    }
    public string ApprovedBy
    {
        get { return m_ApprovedBy; }
        set { m_ApprovedBy = value; }
    }
    public DateTime ApprovedDate
    {
        get { return m_ApprovedDate; }
        set { m_ApprovedDate = value; }
    }
    public int Actived
    {
        get { return m_Actived; }
        set { m_Actived = value; }
    }
    public string Reason
    {
        get { return m_Reason; }
        set { m_Reason = value; }
    }

}