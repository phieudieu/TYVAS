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
    private int m_ViewNbr;
    private string m_Image;
    private int m_Actived;
    private DateTime m_LastModifedDate;
    private string m_LastModifiedUser;
    private int m_TopNbr;
    public Posts()
    {
        m_PID = 0;
        m_Title = String.Empty;
        m_Keyword = String.Empty;
        m_Content = String.Empty;
        m_ShortContent = String.Empty;
        m_CreatedDate = DateTime.MinValue;
        m_CreatedBy = String.Empty;
        m_ViewNbr = 0;
        m_Image = String.Empty;
        m_Actived = 0;
        m_LastModifedDate = DateTime.MinValue;
        m_LastModifiedUser = String.Empty;
        m_TopNbr = 0;
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
    public int ViewNbr
    {
        get { return m_ViewNbr; }
        set { m_ViewNbr = value; }
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
    public string LastModifiedUser
    {
        get { return m_LastModifiedUser; }
        set { m_LastModifiedUser = value; }
    }
    public int TopNbr
    {
        get { return m_TopNbr; }
        set { m_TopNbr = value; }
    }

}