using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Reflection;
using Microsoft.VisualBasic;
using log4net;
using log4net.Config;
using System.Configuration;


/// <summary>
/// Summary description for AccessData
/// </summary>
public class AccessData
{
    ILog m_logger = log4net.LogManager.GetLogger(typeof(AccessData));
    private SqlConnection m_sqlConnection = null;
    private string  m_connectString    = "";

    private  string  GetConnection() 
    {
        StringBuilder s = new StringBuilder();
        try
        {
            s.AppendFormat("Data Source={0};", ConfigurationManager.AppSettings["ServerName"]);
            s.AppendFormat("Initial Catalog={0};", ConfigurationManager.AppSettings["DBName"]);
            s.AppendFormat("User ID={0};", ConfigurationManager.AppSettings["UserName"]);
            s.AppendFormat("Password={0}", ConfigurationManager.AppSettings["Password"]);
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        return s.ToString ();
    }       

    public SqlConnection SqlConnection
    {
        get { return m_sqlConnection; }
        set { m_sqlConnection = value; }
    }

	public AccessData()
	{
        m_connectString = GetConnection();
        m_sqlConnection = new SqlConnection(m_connectString);
	}

    /// <summary>
    /// Open connection
    /// </summary>
    private void OpenConnection()
    {
        if (m_sqlConnection.State == System.Data.ConnectionState.Closed)
        {
            m_sqlConnection.Open();
        }
    }

    /// <summary>
    /// Close connection
    /// </summary>
     private void CloseConnection()
     {
         try
         {
             if ( m_sqlConnection.State != System.Data.ConnectionState.Closed )
             {
                 m_sqlConnection.Close() ;
             }
         }
         catch  (Exception ex )
         {
             m_logger.Error(ex.ToString());
         }
     }

    /// <summary>
    /// Get data
    /// </summary>
    /// <param name="strQuery">String query Ex: select * from user</param>
    /// <returns>DataTable</returns>
     public DataTable GetDataTable( string strQuery)
     {
         DataTable dt = null;
         SqlDataAdapter da = null;
         try
         {
             da = new SqlDataAdapter(strQuery, m_sqlConnection);
             dt= GetDataTable(da);
         }
         catch (Exception ex)
         {
             if ( da !=null )
             {
                 da.Dispose();
             }
             m_logger.Error(ex.ToString());
             throw ex;
         }
         return dt;
     }

    /// <summary>
    /// Get data
    /// </summary>
    /// <param name="adapter">SqlDataAdapter</param>
     /// <returns>DataTable</returns>
     public DataTable GetDataTable(SqlDataAdapter adapter)
     {
         DataTable dt = null;
         DataSet ds = null;
         bool cnn = false;
         try
         {
             ds = new DataSet();
             if (adapter.SelectCommand.Connection != null)
             {
                 adapter.SelectCommand.Connection = m_sqlConnection;
                 cnn = true;
             }
             OpenConnection();
             adapter.Fill(ds);
             if (ds.Tables.Count >0)
             {
                 dt = ds.Tables[0].Copy();
             }
         }
         catch (Exception ex)
         {
             m_logger.Error(ex.ToString());
             throw ex;
         }
         finally
         {
             CloseConnection();
             if (cnn == true)
             {
                 adapter.SelectCommand.Connection = null;
             }
             ds.Dispose();
         }
         return dt;
     }

    /// <summary>
    /// Get 1 record data from database
    /// </summary>
     /// <param name="da">SqlDataAdapter</param>
     /// <returns>DataRow</returns>
     public DataRow GetDataRow(SqlDataAdapter da)
     {
         DataRow dr = null;
         DataTable dt = null;
         DataSet ds = null;
         bool cnn = false;
         try
         {
             if (da.SelectCommand.Connection == null)
             {
                 da.SelectCommand.Connection = m_sqlConnection;
             }
             OpenConnection();
             da.Fill(ds);
             if (ds.Tables.Count > 0)
             {
                 dt = ds.Tables[0].Copy();
                 if (dt.Rows.Count > 0)
                 {
                     dr = dt.Rows[0];
                 }
             }
         }
         catch (Exception ex)
         {
             m_logger.Error(ex.ToString());
             throw ex;
         }
         finally
         {
             CloseConnection();
             if (cnn == true)
             {
                 da.SelectCommand.Connection = null;
             }
             ds.Dispose();
             
         }
         return dr;
     }

    /// <summary>
     /// Execute Non Query
    /// </summary>
    /// <param name="strQuery">String query update, delete.. Ex: Delete user</param>
    /// <returns>record update, delete...</returns>
     public int ExecuteNonQuery( string strQuery)
     {
         int record = 0;
         SqlCommand sqlcmd = null;
         try
         {
             sqlcmd = new SqlCommand(strQuery, m_sqlConnection);
             record = ExecuteNonQuery(sqlcmd);
         }
         catch (Exception ex)
         {
             m_logger.Error(ex.ToString());
            throw ex;
         } 
         finally
         {
              if (sqlcmd != null )
             {
                 sqlcmd.Dispose ();
             }
         }
         return record;
     }

    /// <summary>
     /// Execute Non Query
    /// </summary>
    /// <param name="sqlcmd">SqlCommand</param>
     /// <returns>record update, delete...</returns>
     public int ExecuteNonQuery(SqlCommand sqlcmd)
     {
         int record = 0;
         bool cnn = false;
         try
         {
             if (sqlcmd.Connection == null)
             {
                 sqlcmd.Connection = m_sqlConnection;
                 cnn = true;
             }
             OpenConnection();
             record = sqlcmd.ExecuteNonQuery();
         }
         catch (Exception ex)
         {
             m_logger.Error(ex.ToString());
             throw ex;
         }
         finally
         {
             CloseConnection();
             if (cnn == true)
             {
                 sqlcmd.Connection = null;
             }
         }
         return record;
     }

    /// <summary>
    /// Query return object
    /// </summary>
    /// <param name="strQuery">sql Statement</param>
    /// <returns>Object</returns>
     public object ExecuteScalar(string strQuery)
     {
         object obj = null;
         bool cnn = false;
         SqlCommand sqlcmd = null;
         try
         {
             sqlcmd = new SqlCommand(strQuery, m_sqlConnection);
             if (sqlcmd.Connection == null)
             {
                 sqlcmd.Connection = m_sqlConnection;
                 cnn = true;
             }
             OpenConnection();
             obj  = sqlcmd.ExecuteScalar();
         }
         catch (Exception ex)
         {
             m_logger.Error(ex.ToString());
             throw ex;
         }
         finally
         {
             CloseConnection();
             if (cnn == true)
             {
                 sqlcmd.Connection = null;
             }
         }
         return obj ;
     }

    /// <summary>
    /// Insert new record
    /// </summary>
    /// <param name="table">Table</param>
    /// <param name="row">Object</param>
    /// <param name="column">Column</param>
    /// <returns>record insert</returns>
    public bool InsertRow( string table, object row , string[] column=null )
    {
        string sql = GetInsertSql(table, row, column);
        try
        {
            if (ExecuteNonQuery(sql)>0 )
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
            throw ex ;
        }
        return false;
    }

    /// <summary>
    /// Get sql statement to insert
    /// </summary>
    /// <param name="table">Table</param>
    /// <param name="row">Object</param>
    /// <param name="column">Column</param>
    /// <returns>String statement</returns>
    protected string GetInsertSql(string table, object row, string[] column = null)
    {
        StringBuilder sqltext= new StringBuilder();
        StringBuilder sqltext1 = new StringBuilder();
        StringBuilder sqltext2 = new StringBuilder();
        string c = "";
        PropertyInfo[] pi = null;
        PropertyInfo p = null;
        int i = 0;
        int sz = 0;
        try
        {
            if (row != null)
            {
                if (column != null)
                {
                    sz = column.GetLength(0);
                    for (i = 0; i < sz; i++)
                    {
                        //p = row.GetType().GetProperty(column[i],  BindingFlags.IgnoreCase);
                        p = row.GetType().GetProperty(column[i]);

                        sqltext1.AppendFormat("{0}{1}", c, column[i]);
                        switch (p.PropertyType.FullName)
                        {
                            case "System.DateTime":
                                if (p.GetValue(row, null) == null)
                                {
                                    sqltext2.AppendFormat("{0}{1}", c, "null");
                                }
                                else
                                {
                                    if (Convert.ToDateTime(p.GetValue(row, null)) == DateTime.MinValue)
                                    {
                                        sqltext2.AppendFormat("{0}{1}", c, "null");
                                    }
                                    else
                                    {
                                        sqltext2.AppendFormat("{0}'{1}'", c, p.GetValue(row, null));
                                    }
                                }
                                break;
                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                            case "System.UInt16":
                            case "System.UInt32":
                            case "System.UInt64":
                            case "System.Double":
                            case "System.Single":
                            case "System.Decimal":
                                sqltext2.AppendFormat("{0}{1}", c, p.GetValue(row, null));
                                break;
                            default:
                                if (p.GetValue(row, null) != null)
                                {
                                    sqltext2.AppendFormat("{0}'{1}'", c, p.GetValue(row, null));
                                }
                                break;
                        }
                        c = ",";
                    }
                    sqltext.AppendFormat("INSERT INTO {0} ({1}) VALUES ({2})", table, sqltext1, sqltext2);
                }
                else
                {
                    pi = row.GetType().GetProperties();
                    foreach (PropertyInfo item in pi)
                    {
                        sqltext1.AppendFormat("{0}{1}", c, item.Name);
                        switch (item.PropertyType.FullName)
                        {
                            case "System.DateTime":
                                if (item.GetValue(row, null) == null)
                                {
                                    sqltext2.AppendFormat("{0}{1}", c, "null");
                                }
                                else
                                {
                                    if (Convert.ToDateTime(item.GetValue(row, null)) == DateTime.MinValue)
                                    {
                                        sqltext2.AppendFormat("{0}{1}", c, "null");
                                    }
                                    else
                                    {
                                        sqltext2.AppendFormat("{0}'{1}'", c, item.GetValue(row, null));
                                    }
                                }
                                break;
                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                            case "System.UInt16":
                            case "System.UInt32":
                            case "System.UInt64":
                            case "System.Double":
                            case "System.Single":
                            case "System.Decimal":
                                sqltext2.AppendFormat("{0}{1}", c, item.GetValue(row, null));
                                break;
                            default:
                                if (item.GetValue(row, null) != null)
                                {
                                    sqltext2.AppendFormat("{0}'{1}'", c, item.GetValue(row, null));
                                }
                                break;
                        }
                        c = ",";
                    }
                    sqltext.AppendFormat("INSERT INTO {0} ({1}) VALUES ({2})", table, sqltext1.ToString (), sqltext2.ToString ());
                }
            }
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        m_logger.Info(sqltext.ToString ());
        return sqltext.ToString();
    }

    public bool  UpdateRow(string table, object row, string[] column ,string where="")
    {
        string sql = GetUpdateSql(  table, row, column ,where )  ;
        if (ExecuteNonQuery(sql) > 0)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Sql statement update
    /// </summary>
    /// <param name="table">Table update</param>
    /// <param name="row">Object</param>
    /// <param name="column">Column</param>
    /// <param name="where">condition to update ex: name = 'Oliver'</param>
    /// <returns>Statement</returns>
    protected string GetUpdateSql(string table, object row, string[] column = null, string where="")
    {
        StringBuilder sqltext = new StringBuilder();
        StringBuilder sqltext1 = new StringBuilder();
        StringBuilder sqltext2 = new StringBuilder();
        string c = "";
        PropertyInfo[] pi = null;
        PropertyInfo p = null;
        int i = 0;
        int sz = 0;
        try
        {
            if (row == null)
            {
                if (column == null)
                {
                    sqltext.AppendFormat("UPDATE {0} SET ", table);
                    sz = column.GetLength(0);
                    for (i = 0; i < sz; i++)
                    {
                        p = row.GetType().GetProperty(column[i], BindingFlags.IgnoreCase);
                        sqltext2.AppendFormat("", c, column[i]);
                        switch (p.PropertyType.FullName)
                        {
                            case "System.DateTime":
                                if (p.GetValue(row, null) == null)
                                {
                                    sqltext2.AppendFormat("{0}{1}={2}", c, column[i], "null");
                                }
                                else
                                {
                                    if (Convert.ToDateTime(p.GetValue(row, null)) == DateTime.MinValue)
                                    {
                                        sqltext2.AppendFormat("{0}{1}={2}", c, column[i], "null");
                                    }
                                    else
                                    {
                                        sqltext2.AppendFormat("{0}{1}='{2}'", c, column[i], p.GetValue(row, null));
                                    }
                                }
                                break;
                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                            case "System.UInt16":
                            case "System.UInt32":
                            case "System.UInt64":
                            case "System.Double":
                            case "System.Single":
                            case "System.Decimal":
                                sqltext2.AppendFormat("{0}{1}={2}", c, column[i], p.GetValue(row, null));
                                break;
                            default:
                                if (p.GetValue(row, null) != null)
                                {
                                    sqltext2.AppendFormat("{0}{1}='{2}'", c, column[i], p.GetValue(row, null));
                                }
                                break;
                        }
                        c = ",";
                    }
                }
                else
                {
                    sqltext.AppendFormat("UPDATE {0} SET ", table);
                    pi = row.GetType().GetProperties();
                    foreach (PropertyInfo item in pi)
                    {
                        switch (item.PropertyType.FullName)
                        {
                            case "System.DateTime":
                                if (item.GetValue(row, null) == null)
                                {
                                    sqltext2.AppendFormat("{0}{1}={2}", c, p.Name, "null");
                                }
                                else
                                {
                                    if (Convert.ToDateTime(item.GetValue(row, null)) == DateTime.MinValue)
                                    {
                                        sqltext2.AppendFormat("{0}{1}={2}", c, p.Name, "null");
                                    }
                                    else
                                    {
                                        sqltext2.AppendFormat("{0}{1}='{2}'", c, p.Name, item.GetValue(row, null));
                                    }
                                }
                                break;
                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                            case "System.UInt16":
                            case "System.UInt32":
                            case "System.UInt64":
                            case "System.Double":
                            case "System.Single":
                            case "System.Decimal":
                                sqltext2.AppendFormat("{0}{1}={2}", c, p.Name, item.GetValue(row, null));
                                break;
                            default:
                                if (item.GetValue(row, null) != null)
                                {
                                    sqltext2.AppendFormat("{0}{1}='{2}'", c, p.Name, item.GetValue(row, null));
                                }
                                break;
                        }
                        c = ",";
                    }
                }
            }
            if (where != "")
            {
                sqltext.AppendFormat(" WHERE {0}", where);
            }  
        }
        catch (Exception ex)
        {
            m_logger.Error(ex.ToString());
        }
        m_logger.Info(sqltext.ToString ());
        return sqltext.ToString();
    }
    
    /// <summary>
    /// Delete table by condition
    /// </summary>
    /// <param name="table">Table name</param>
    /// <param name="where">condition to delte Ex: id = 1</param>
    /// <returns>Num row deleted</returns>
    public int DeleteRow(string table, string where)
    {
        string sql = string.Format("Delete {0} where {1}", table, where);
        return ExecuteNonQuery(sql);
    }

    /// <summary>
    /// Delete table
    /// </summary>
    /// <param name="table">Table name</param>
    /// <returns></returns>
    public int DeleteAll(string table)
    {
        string sql = string.Format("Delete {0} ", table);
        return ExecuteNonQuery(sql);
    }
}