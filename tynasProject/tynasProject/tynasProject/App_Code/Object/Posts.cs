using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Posts
/// </summary>
public class Posts
{
    private int m_PID;
    private string m_Title;
    private string m_Keyword;
    private string m_Content;
    private string m_ShortContent;
    private DateTime m_CreatedDate;
    private string m_CreatedBy;
    private int m_View;
    private string m_Image;
    private int m_Actived;
    private DateTime m_LastModifedDate;
    private DateTime m_LastModifiedUser;
    private int m_Top;
    public Posts()
    {
        m_PID = 0;
        m_Title = String.Empty;
        m_Keyword = String.Empty;
        m_Content = String.Empty;
        m_ShortContent = String.Empty;
        m_CreatedDate = DateTime.MinValue;
        m_CreatedBy = String.Empty;
        m_View = 0;
        m_Image = String.Empty;
        m_Actived = 0;
        m_LastModifedDate = DateTime.MinValue;
        m_LastModifiedUser = DateTime.MinValue;
        m_Top = 0;
    }
    public int PID
    {
        get { return m_PID; }
        set { m_PID = value; }
    }
    public string Title
    {
        get { return m_Title; }
        set { m_Title = value; }
    }
    public string Keyword
    {
        get { return m_Keyword; }
        set { m_Keyword = value; }
    }
    public string Content
    {
        get { return m_Content; }
        set { m_Content = value; }
    }
    public string ShortContent
    {
        get { return m_ShortContent; }
        set { m_ShortContent = value; }
    }
    public DateTime CreatedDate
    {
        get { return m_CreatedDate; }
        set { m_CreatedDate = value; }
    }
    public string CreatedBy
    {
        get { return m_CreatedBy; }
        set { m_CreatedBy = value; }
    }
    public int View
    {
        get { return m_View; }
        set { m_View = value; }
    }
    public string Image
    {
        get { return m_Image; }
        set { m_Image = value; }
    }
    public int Actived
    {
        get { return m_Actived; }
        set { m_Actived = value; }
    }
    public DateTime LastModifedDate
    {
        get { return m_LastModifedDate; }
        set { m_LastModifedDate = value; }
    }
    public DateTime LastModifiedUser
    {
        get { return m_LastModifiedUser; }
        set { m_LastModifiedUser = value; }
    }
    public int Top
    {
        get { return m_Top; }
        set { m_Top = value; }
    }

}