using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SponsorEvent
/// </summary>
public class SponsorEvent
{
    private int  m_IDSponsor;
    private int m_IDEvent;
    private Decimal m_Donate;
    private DateTime m_CreatedDate;
    private DateTime m_LastModifedDate;
    private string m_CreatedUser;
    private string m_LastModifiedUser;
    public SponsorEvent()
    {
        m_IDSponsor = 0;
        m_IDEvent = 0;
        m_Donate = 0;
        m_CreatedDate = DateTime.MinValue;
        m_LastModifedDate = DateTime.MinValue;
        m_CreatedUser = String.Empty;
        m_LastModifiedUser = String.Empty;
    }
    public int  IDSponsor
    {
        get { return m_IDSponsor; }
        set { m_IDSponsor = value; }
    }
    public int IDEvent
    {
        get { return m_IDEvent; }
        set { m_IDEvent = value; }
    }
    public Decimal Donate
    {
        get { return m_Donate; }
        set { m_Donate = value; }
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
    public string CreatedUser
    {
        get { return m_CreatedUser; }
        set { m_CreatedUser = value; }
    }
    public string  LastModifiedUser
    {
        get { return m_LastModifiedUser; }
        set { m_LastModifiedUser = value; }
    }

}