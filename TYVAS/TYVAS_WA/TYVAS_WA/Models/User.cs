using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

/// <summary>
/// Summary description for User
/// </summary>
public class Users
{
    private string m_UserID;
    private string m_FirstName;
    private string m_LMName;
    private int m_Sex;
    private string m_Email;
    private DateTime m_BirthDay;
    private string m_UserName;
    private string m_PassWord;
    private string m_Image;
    private DateTime m_CreatedDate;
    private DateTime m_LastUpdate;
    private int m_Actived;
    private int m_Status;
    private string m_IDReset;
    public Users()
    {
        m_UserID = String.Empty;
        m_FirstName = String.Empty;
        m_LMName = String.Empty;
        m_Sex = 0;
        m_Email = String.Empty;
        m_BirthDay = DateTime.MinValue;
        m_UserName = String.Empty;
        m_PassWord = String.Empty;
        m_Image = String.Empty;
        m_CreatedDate = DateTime.MinValue;
        m_LastUpdate = DateTime.MinValue;
        m_Actived = 0;
        m_Status = 0;
        m_IDReset = String.Empty;
    }
    public string UserID
    {
        get { return m_UserID; }
        set { m_UserID = value; }
    }
    public string FirstName
    {
        get { return m_FirstName; }
        set { m_FirstName = value; }
    }
    public string LMName
    {
        get { return m_LMName; }
        set { m_LMName = value; }
    }
    public int Sex
    {
        get { return m_Sex; }
        set { m_Sex = value; }
    }
    public string Email
    {
        get { return m_Email; }
        set { m_Email = value; }
    }
    public DateTime BirthDay
    {
        get { return m_BirthDay; }
        set { m_BirthDay = value; }
    }
    public string UserName
    {
        get { return m_UserName; }
        set { m_UserName = value; }
    }
    public string PassWord
    {
        get { return m_PassWord; }
        set { m_PassWord = value; }
    }
    public string Image
    {
        get { return m_Image; }
        set { m_Image = value; }
    }
    public DateTime CreatedDate
    {
        get { return m_CreatedDate; }
        set { m_CreatedDate = value; }
    }
    public DateTime LastUpdate
    {
        get { return m_LastUpdate; }
        set { m_LastUpdate = value; }
    }
    public int Actived
    {
        get { return m_Actived; }
        set { m_Actived = value; }
    }
    public int Status
    {
        get { return m_Status; }
        set { m_Status = value; }
    }
    public string IDReset
    {
        get { return m_IDReset; }
        set { m_IDReset = value; }
    }

}