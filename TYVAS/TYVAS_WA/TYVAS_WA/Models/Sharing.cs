using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Sharing
/// </summary>
public class Sharing
{
    private int m_ID;
    private string m_Title;
    private string m_Description;
    private string m_Author;
    private DateTime m_CreatedDate;
    private DateTime m_LastModifedDate;
    private string m_LastModifiedUser;
    public Sharing()
    {
        m_ID = 0;
        m_Title = String.Empty;
        m_Description = String.Empty;
        m_Author = String.Empty;
        m_CreatedDate = DateTime.MinValue;
        m_LastModifedDate = DateTime.MinValue;
        m_LastModifiedUser = String.Empty;
    }
    public int ID
    {
        get { return m_ID; }
        set { m_ID = value; }
    }
    public string Title
    {
        get { return m_Title; }
        set { m_Title = value; }
    }
    public string Description
    {
        get { return m_Description; }
        set { m_Description = value; }
    }
    public string Author
    {
        get { return m_Author; }
        set { m_Author = value; }
    }
    public DateTime CreatedDate
    {
        get { return m_CreatedDate; }
        set { m_CreatedDate = value; }
    }
    public DateTime LastModifedDate
    {
        get { return m_LastModifedDate; }
        set { m_LastModifedDate = value; }
    }
    public string  LastModifiedUser
    {
        get { return m_LastModifiedUser; }
        set { m_LastModifiedUser = value; }
    }

}