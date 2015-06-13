using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AttenderEvent
/// </summary>
public class AttenderEvent
{
    private int m_IDAttender;
    private int m_IDEvent;
    private int m_CompletedFee;
    private DateTime m_CreatedDate;
    private DateTime m_LastModifedDate;
    private DateTime m_CreatedUser;
    private DateTime m_LastModifiedUser;
    public AttenderEvent()
    {
        m_IDAttender = 0;
        m_IDEvent = 0;
        m_CompletedFee = 0;
        m_CreatedDate = DateTime.MinValue;
        m_LastModifedDate = DateTime.MinValue;
        m_CreatedUser = DateTime.MinValue;
        m_LastModifiedUser = DateTime.MinValue;
    }
    public int IDAttender
    {
        get { return m_IDAttender; }
        set { m_IDAttender = value; }
    }
    public int IDEvent
    {
        get { return m_IDEvent; }
        set { m_IDEvent = value; }
    }
    public int CompletedFee
    {
        get { return m_CompletedFee; }
        set { m_CompletedFee = value; }
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
    public DateTime CreatedUser
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