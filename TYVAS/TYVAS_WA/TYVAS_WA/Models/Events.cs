using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Events
/// </summary>
public class Events
{
    private int m_ID;
    private string m_Title;
    private string m_Description;
    private string m_Address;
    private string m_Reference;
    private DateTime m_StartDate;
    private DateTime m_EndDate;
    private string m_Images;
    private string m_Banner;
    private int m_Status;
    private Decimal m_Amount;
    private Decimal m_FeeJoin;
    private DateTime m_CreatedDate;
    private DateTime m_LastModifedDate;
    private string m_CreatedUser;
    private string m_LastModifiedUser;
    private int m_NUMBER;
    private List<Reference> m_Referercer;

    private string m_SStartDate;
    private string m_SEndDate;
    private string m_SCreatedDate;
    private string m_SLastModifedDate;

    public Events()
    {
        m_ID = 0;
        m_Title = String.Empty;
        m_Description = String.Empty;
        m_Address = String.Empty;
        m_Reference = String.Empty;
        m_StartDate = DateTime.MinValue;
        m_EndDate = DateTime.MinValue;
        m_Images = String.Empty;
        m_Banner = String.Empty;
        m_Status = 0;
        m_Amount = 0;
        m_FeeJoin = 0;
        m_CreatedDate = DateTime.MinValue;
        m_LastModifedDate = DateTime.MinValue;
        m_CreatedUser = String.Empty;
        m_LastModifiedUser = String.Empty;
        m_Referercer = new List<Reference>();
        m_NUMBER = 0;
        m_SStartDate = String.Empty;
        m_SEndDate = String.Empty;
        m_SCreatedDate = String.Empty;
        m_SLastModifedDate = String.Empty;
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
    public string Description
    {
        get { return m_Description; }
        set { m_Description = value; }
    }
    public string Address
    {
        get { return m_Address; }
        set { m_Address = value; }
    }
    public string Reference
    {
        get { return m_Reference; }
        set { m_Reference = value; }
    }
    public DateTime StartDate
    {
        get { return m_StartDate; }
        set { m_StartDate = value; }
    }
    public DateTime EndDate
    {
        get { return m_EndDate; }
        set { m_EndDate = value; }
    }
    public string Images
    {
        get { return m_Images; }
        set { m_Images = value; }
    }
    public string Banner
    {
        get { return m_Banner; }
        set { m_Banner = value; }
    }
    public int Status
    {
        get { return m_Status; }
        set { m_Status = value; }
    }
    public Decimal Amount
    {
        get { return m_Amount; }
        set { m_Amount = value; }
    }
    public Decimal FeeJoin
    {
        get { return m_FeeJoin; }
        set { m_FeeJoin = value; }
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
    public string  LastModifiedUser
    {
        get { return m_LastModifiedUser; }
        set { m_LastModifiedUser = value; }
    }
    public int NUMBER
    {
        get { return m_NUMBER ; }
        set { m_NUMBER = value; }
    }
    public List<Reference> Referercer
    {
        get {
             List<Reference> re= new List<global::Reference>() ;
            string []arr = m_Reference.Split(new string[] { "[!!]" }, StringSplitOptions.None );
            foreach (string item in arr)
            {
                if (!item.Equals(""))
                {
                    string[] arr1 = item.Split(new string[] { "[!]" }, StringSplitOptions.None);
                    if (arr1.Length > 0)
                    {
                        Reference itemre = new Reference();
                        itemre.Name = arr1[0];
                        if (arr1.Length > 1)
                        {
                            itemre.Address = arr1[1];
                        }
                        if (arr1.Length > 2)
                        {
                            itemre.Phone = arr1[2];
                        }
                        re.Add(itemre);
                    }
                }               
            }

            return re; 
        } 
        set { m_Referercer = value; }
    }

    public void SetReferercer()
    {
        Reference="";
        foreach (Reference item in m_Referercer)
        {
            if (Reference.Equals(""))
            {
                Reference = item.Name + "[!]" + item.Address + "[!]" + item.Phone;
            }
            else
            {
                Reference = Reference + "[!!]" + item.Name + "[!]" + item.Address + "[!]" + item.Phone;
            }
        }
    }

    public void SetDateTime()
    {
        try
        {
            StartDate = Convert.ToDateTime(SStartDate);
            EndDate = Convert.ToDateTime(SEndDate);
            CreatedDate = Convert.ToDateTime(SCreatedDate);
            LastModifedDate = Convert.ToDateTime(SLastModifedDate);
        }
        catch (Exception ex)
        {            
        }       
    }

    public string SStartDate
    {
        get { return m_StartDate.ToString(); }
        set { m_SStartDate = value; }
    }

    public string SEndDate
    {
        get { return m_EndDate.ToString (); }
        set { m_SEndDate = value; }
    }

    public string SCreatedDate
    {
        get { return m_CreatedDate.ToString(); }
        set { m_SCreatedDate = value; }
    }

    public string SLastModifedDate
    {
        get { return m_LastModifedDate.ToString(); }
        set { m_SLastModifedDate = value; }
    }

}