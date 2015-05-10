using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{
    private int m_ID;
    private string m_Name;
    private string m_Description;
    private string m_Link;
    public Category()
    {
        m_ID = 0;
        m_Name = String.Empty;
        m_Description = String.Empty;
        m_Link = String.Empty;
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
    public string Description
    {
        get { return m_Description; }
        set { m_Description = value; }
    }
    public string Link
    {
        get { return m_Link; }
        set { m_Link = value; }
    }

}