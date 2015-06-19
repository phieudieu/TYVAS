using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Reference
{
    private string m_Name;
    private string m_Address;
    private string m_Phone;

    public Reference()
    {
        m_Name =string.Empty ;
        m_Address = string.Empty;
        m_Phone = string.Empty;
    }
    public string  Name
    {
        get { return m_Name; }
        set { m_Name = value; }
    }
    public string  Address
    {
        get { return m_Address; }
        set { m_Address = value; }
    }
    public string  Phone
    {
        get { return m_Phone; }
        set { m_Phone = value; }
    }

}