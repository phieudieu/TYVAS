using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Banner
/// </summary>
public class Banner
{
    private int m_ID;
    private string m_Description;
    private string m_ImageName;
    private string m_Path;
    public Banner()
    {
        m_ID = 0;
        m_Description = String.Empty;
        m_ImageName = String.Empty;
        m_Path = String.Empty;
    }
    public int ID
    {
        get { return m_ID; }
        set { m_ID = value; }
    }
    public string Description
    {
        get { return m_Description; }
        set { m_Description = value; }
    }
    public string ImageName
    {
        get { return m_ImageName; }
        set { m_ImageName = value; }
    }
    public string Path
    {
        get { return m_Path; }
        set { m_Path = value; }
    }

}