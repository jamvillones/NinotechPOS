using POS.Forms;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;


namespace Connections
{
    public static class ContextTools
    {

        public static void ChangeDatabase(this DbContext source)
        {
            try
            {
                //var settins = POS.Properties.Settings.Default;
                // use the const name if it's not null, otherwise
                // using the convention of connection string = EF contextname
                // grab the type name and we're done
                var configNameEf = source.GetType().Name;

                // add a reference to System.Configuration
                var entityCnxStringBuilder = new EntityConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[configNameEf].ConnectionString);

                // init the sqlbuilder with the full EF connectionstring cargo
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder(entityCnxStringBuilder.ProviderConnectionString);
                ConnectionConfigurationProfile currentConfig = ConnectionConfiguration_Source.CurrentConfiguration;

                sqlCnxStringBuilder.DataSource = currentConfig.Connection;

                if (currentConfig.Port is null)
                {
                    sqlCnxStringBuilder.TrustServerCertificate = true;
                    sqlCnxStringBuilder.IntegratedSecurity = true;
                }

                if (currentConfig.Username != null)
                    sqlCnxStringBuilder.UserID = currentConfig.Username;

                if (currentConfig.Password != null)
                    sqlCnxStringBuilder.Password = currentConfig.Password;

                // now flip the properties that were changed
                source.Database.Connection.ConnectionString
                    = sqlCnxStringBuilder.ConnectionString;
            }
            catch (Exception ex)
            {
                // set log item if required
                Console.WriteLine(ex.Message);
            }
        }

        public static void TestConnection
            (this DbContext context, ConnectionConfigurationProfile currentConfig)
        {
            try
            {
                //var settings = POS.Properties.Settings.Default;
                // use the const name if it's not null, otherwise
                // using the convention of connection string = EF contextname
                // grab the type name and we're done
                var configNameEf = context.GetType().Name;

                // add a reference to System.Configuration
                var entityCnxStringBuilder = new EntityConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[configNameEf].ConnectionString);

                // init the sqlbuilder with the full EF connectionstring cargo
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder(entityCnxStringBuilder.ProviderConnectionString);

                sqlCnxStringBuilder.DataSource = currentConfig.Connection;

                if (currentConfig.Port is null)
                {
                    sqlCnxStringBuilder.TrustServerCertificate = true;
                    sqlCnxStringBuilder.IntegratedSecurity = true;
                }

                if (currentConfig.Username != null)
                    sqlCnxStringBuilder.UserID = currentConfig.Username;

                if (currentConfig.Password != null)
                    sqlCnxStringBuilder.Password = currentConfig.Password;

                //if (isLocalConnection)
                //{
                //    string machineName = System.Environment.MachineName;
                //    sqlCnxStringBuilder.DataSource = machineName + "\\SQLEXPRESS";
                //    sqlCnxStringBuilder.TrustServerCertificate = true;
                //    sqlCnxStringBuilder.IntegratedSecurity = true;
                //}
                //else
                //{
                //    sqlCnxStringBuilder.DataSource = dataSource + "," + portName;
                //    sqlCnxStringBuilder.UserID = id;
                //    sqlCnxStringBuilder.Password = pass;
                //}

                //// set the integrated security status
                //sqlCnxStringBuilder.IntegratedSecurity = false;
                // now flip the properties that were changed
                context.Database.Connection.ConnectionString = sqlCnxStringBuilder.ConnectionString;
            }
            catch (Exception ex)
            {
                // set log item if required
                Console.WriteLine(ex.Message);
            }
        }

        public static void ChangeDatabase(this DbContext source, string dataSource, string portName, string id, string pass, bool isLocalConnection = true)
        {
            try
            {
                //var settings = POS.Properties.Settings.Default;
                // use the const name if it's not null, otherwise
                // using the convention of connection string = EF contextname
                // grab the type name and we're done
                var configNameEf = source.GetType().Name;

                // add a reference to System.Configuration
                var entityCnxStringBuilder = new EntityConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[configNameEf].ConnectionString);

                // init the sqlbuilder with the full EF connectionstring cargo
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder(entityCnxStringBuilder.ProviderConnectionString);

                if (isLocalConnection)
                {
                    string machineName = System.Environment.MachineName;
                    sqlCnxStringBuilder.DataSource = machineName + "\\SQLEXPRESS";
                    sqlCnxStringBuilder.TrustServerCertificate = true;
                    sqlCnxStringBuilder.IntegratedSecurity = true;
                }
                else
                {
                    sqlCnxStringBuilder.DataSource = dataSource + "," + portName;
                    sqlCnxStringBuilder.UserID = id;
                    sqlCnxStringBuilder.Password = pass;
                }

                //// set the integrated security status
                //sqlCnxStringBuilder.IntegratedSecurity = false;
                // now flip the properties that were changed
                source.Database.Connection.ConnectionString = sqlCnxStringBuilder.ConnectionString;
            }
            catch (Exception ex)
            {
                // set log item if required
                Console.WriteLine(ex.Message);
            }
        }



        /// <summary>
        /// HAHAHA just a neat way to use DBcontext? ;) I think? - Jam Villones
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="isContextSaving"></param>
        /// <returns></returns>
        public static bool UseContext<T>(Action<T> action, bool isContextSaving = true) where T : DbContext, new()
        {
            T context = null;
            bool result = false;

            try
            {
                context = new T();

                context.ChangeDatabase();

                action(context);

                if (isContextSaving)
                    context.SaveChanges();

                result = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                context?.Dispose();
            }

            return result;
        }
    }
}