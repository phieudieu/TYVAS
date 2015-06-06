using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TYASInfo
/// </summary>
public class TYASInfo
{
	  
    private int m_ID;
    private string m_Name;
    private string m_Content;
    public TYASInfo()
    {
        m_ID = 0;
        m_Name = String.Empty;
        m_Content = String.Empty;
    }
    public int ID
    {
        get { return m_ID; }
        set { m_ID = value; }
    }
    public string Name
    {
        get { return m_Name; }
        set { m_Name = value; }
    }
    public string Content
    {
        get { return m_Content; }
        set { m_Content = value; }
    }

}