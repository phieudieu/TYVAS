using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text ;

/// <summary>
/// Summary description for Attender
/// </summary>
public class Attender
{
    private int m_ID;
    private string m_FullName;
    private string m_Email;
    private string m_Phone;
    private string m_Address;
    private int m_Type;
    private DateTime m_CreatedDate;
    private DateTime m_LastModifedDate;
    private string  m_CreatedUser;
    private DateTime m_LastModifiedUser;
    public Attender()
    {
        m_ID = 0;
        m_FullName = String.Empty;
        m_Email = String.Empty;
        m_Phone = String.Empty;
        m_Address = String.Empty;
        m_Type = 0;
        m_CreatedDate = DateTime.MinValue;
        m_LastModifedDate = DateTime.MinValue;
        m_CreatedUser = string.Empty ;
        m_LastModifiedUser = DateTime.MinValue;
    }
    public int ID
    {
        get { return m_ID; }
        set { m_ID = value; }
    }
    public string FullName
    {
        get { return m_FullName; }
        set { m_FullName = value; }
    }
    public string Email
    {
        get { return m_Email; }
        set { m_Email = value; }
    }
    public string Phone
    {
        get { return m_Phone; }
        set { m_Phone = value; }
    }
    public string Address
    {
        get { return m_Address; }
        set { m_Address = value; }
    }
    public int Type
    {
        get { return m_Type; }
        set { m_Type = value; }
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
    public string  CreatedUser
    {
        get { return m_CreatedUser; }
        set { m_CreatedUser = value; }
    }
    public DateTime LastModifiedUser
    {
        get { return m_LastModifiedUser; }
        set { m_LastModifiedUser = value; }
    }



}