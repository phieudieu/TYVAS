using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

/// <summary>
/// Summary description for Doccument
/// </summary>
public class Doccument
{
    private int m_ID;
    private string m_Title;
    private Image m_Document;
    private string m_Path;
    public Doccument()
    {
        m_ID = 0;
        m_Title = String.Empty;
        m_Document = null;
        m_Path = String.Empty;
    }
    public int ID
    {
        get { return m_ID; }
        set { m_ID = value; }
    }
    public string Title
    {
        get { return m_Title; }
        set { m_Title = value; }
    }
    public Image Document
    {
        get { return m_Document; }
        set { m_Document = value; }
    }
    public string Path
    {
        get { return m_Path; }
        set { m_Path = value; }
    }


}