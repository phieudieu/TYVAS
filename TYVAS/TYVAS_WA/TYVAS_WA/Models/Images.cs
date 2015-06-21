using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Images
{
    private string m_ImageName;   
    private string m_ImageType;
    private string m_SaveAsFolder; 
    private byte[] m_ImageData;
   
    public Images()
    {
        m_ImageName = "";
        m_ImageType = "";
        m_ImageData = null;
        m_SaveAsFolder = "";
    }

    public string ImageName
    {
        get { return m_ImageName; }
        set { m_ImageName = value; }
    }

    public string ImageType
    {
        get { return m_ImageType; }
        set { m_ImageType = value; }
    }

    public byte[] ImageData
    {
        get { return m_ImageData; }
        set { m_ImageData = value; }
    }

    public string  SaveAsFolder
    {
        get { return m_SaveAsFolder; }
        set { m_SaveAsFolder = value; }
    }

}