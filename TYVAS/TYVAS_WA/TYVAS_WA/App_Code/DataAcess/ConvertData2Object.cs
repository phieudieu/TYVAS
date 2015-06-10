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
       
    }
 