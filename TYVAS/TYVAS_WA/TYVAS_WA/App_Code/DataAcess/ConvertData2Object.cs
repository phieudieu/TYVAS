using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Data;

 
    public static class ConvertData2Object1
    {      

        /// <summary>
        /// Create item from datarow
        /// </summary>
        /// <typeparam name="T">Object return</typeparam>
        /// <param name="row">Object</param>
        /// <param name="properties">List properties of Object</param>
        /// <returns>Object</returns>
        public static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                property.SetValue(item, row[property.Name], null);
            }
            return item;
        }

        /// <summary>
        /// List object
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="table">Table</param>
        /// <returns>Object lst</returns>
        public static List<T> DataTableToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }


        //public List<Attender> GetAll_Attender()
        //{
        //    List<Attender> attList = new List<Attender>();
        //    string sqltext = "select * from attender";
        //    try
        //    {
        //        DataTable dt = m_da.GetDataTable(sqltext);
        //        attList =  DataTableToList(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        m_logger.Error(ex.ToString());
        //    }
        //    return attList;
        //}


        //public Attender CreateItemFromRow(DataRow row, IList<PropertyInfo> properties) 
        //{
        //    Attender item = new Attender();
        //    try
        //    {
        //        foreach (var property in properties)
        //        {
        //            property.SetValue(item, row[property.Name], null);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        m_logger.Error(ex.ToString());
        //    }       
        //    return item;
        //}

        //public List<Attender> DataTableToList( DataTable table)  
        //{
        //    IList<PropertyInfo> properties = typeof(Attender).GetProperties().ToList();
        //    List<Attender> result = new List<Attender>();
        //    try
        //    {
        //        for (int i = 0; i < table.Rows.Count; i++)
        //        {
        //            Attender item = CreateItemFromRow((DataRow)table.Rows[i], properties);
        //            result.Add(item);
        //        }            
        //    }
        //    catch (Exception ex)
        //    {
        //        m_logger.Error(ex.ToString());
        //    }  
        //    return result;
        //}

    }
 