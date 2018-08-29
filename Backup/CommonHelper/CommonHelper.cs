using Storemey.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Storemey.Web.CommonHelper
{
    public static class CommonWebHelper
    {

        /// <summary>  
        /// This is a Helper Method For Image Element  
        /// </summary>  
        /// <param name="Source">Provide Source</param>  
        /// <param name="Alt">alt Attribute For That Image</param>  
        /// <param name="Title">Title For the Image</param>  
        /// <param name="Height">Height Attribute (By Default Height will be 128)</param>  
        /// <param name="Width">Width Attribute (By Default Width will be 128)</param>  
        /// <returns></returns>  
        public static string img(string Source, string Alt, string Title, int Height = 128, int Width = 128)
        {
            return String.Format("<img src='{0}' alt='{1}' title='{2}' height='{3}' width='{4}'/>", Source, Alt, Title, Height, Width);
        }

        /// <summary>  
        /// This is a Helper Method For Image Element  
        /// </summary> 
        /// 

        public static string TenancyConnectionString(string HostName)
        {
            string ConnectionString = string.Empty;
            if (!string.IsNullOrEmpty(HostName))
            {
                ConnectionString =  ConfigurationManager.AppSettings["dbConnectionString"].Replace("[dbName]", HostName);
            }
            else
            {
                ConnectionString = ConfigurationManager.AppSettings["dbConnectionString"].Replace("[dbName]", "StoremeyMaster");
            }
            return ConnectionString;
        }


        // all params are optional
        public static void ChangeDatabase(
            this StoremeyDbContext source,
            string initialCatalog = "",
            string dataSource = "",
            string userId = "",
            string password = "",
            bool integratedSecuity = true,
            string configConnectionStringName = "",
            string fullConnectionString = "")
        /* this would be used if the
        *  connectionString name varied from 
        *  the base EF class name */
        {
            try
            {



                Database.SetInitializer<StoremeyDbContext>(null);



                // use the const name if it's not null, otherwise
                // using the convention of connection string = EF contextname
                // grab the type name and we're done
                var configNameEf = string.IsNullOrEmpty(configConnectionStringName)
                    ? source.GetType().Name
                    : configConnectionStringName;

                // add a reference to System.Configuration
                //var entityCnxStringBuilder = new EntityConnectionStringBuilder
                //    (fullConnectionString);

                // init the sqlbuilder with the full EF connectionstring cargo
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder
                    (fullConnectionString);

                // only populate parameters with values if added
                if (!string.IsNullOrEmpty(initialCatalog))
                    sqlCnxStringBuilder.InitialCatalog = initialCatalog;
                if (!string.IsNullOrEmpty(dataSource))
                    sqlCnxStringBuilder.DataSource = dataSource;
                if (!string.IsNullOrEmpty(userId))
                    sqlCnxStringBuilder.UserID = userId;
                if (!string.IsNullOrEmpty(password))
                    sqlCnxStringBuilder.Password = password;

                // set the integrated security status
                sqlCnxStringBuilder.IntegratedSecurity = integratedSecuity;





                // now flip the properties that were changed
                source.Database.Connection.ConnectionString
                    = sqlCnxStringBuilder.ConnectionString;
            }
            catch (Exception ex)
            {
                // set log item if required
            }
        }

    }
}