using System;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;


namespace Connections
{
    public static class Tools
    {

        public static void ChangeDatabase(this DbContext source)
        {
            try
            {
                var settins = POS.Properties.Settings.Default;
                // use the const name if it's not null, otherwise
                // using the convention of connection string = EF contextname
                // grab the type name and we're done
                var configNameEf = source.GetType().Name;

                // add a reference to System.Configuration
                var entityCnxStringBuilder = new EntityConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[configNameEf].ConnectionString);

                // init the sqlbuilder with the full EF connectionstring cargo
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder(entityCnxStringBuilder.ProviderConnectionString);

                sqlCnxStringBuilder.DataSource = settins.DataSource + "," + settins.PortName;
                sqlCnxStringBuilder.UserID = settins.UserId;
                sqlCnxStringBuilder.Password = settins.Password;

                //// set the integrated security status
                //sqlCnxStringBuilder.IntegratedSecurity = false;
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

        public static void ChangeDatabase(this DbContext source, string dataSource, string portName, string id, string pass)
        {
            try
            {
                var settins = POS.Properties.Settings.Default;
                // use the const name if it's not null, otherwise
                // using the convention of connection string = EF contextname
                // grab the type name and we're done
                var configNameEf = source.GetType().Name;

                // add a reference to System.Configuration
                var entityCnxStringBuilder = new EntityConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[configNameEf].ConnectionString);

                // init the sqlbuilder with the full EF connectionstring cargo
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder(entityCnxStringBuilder.ProviderConnectionString);

                sqlCnxStringBuilder.DataSource = dataSource + "," + portName;
                sqlCnxStringBuilder.UserID = id;
                sqlCnxStringBuilder.Password = pass;

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

        //public static string ConString
        //{
        //    get
        //    {
        //        var sqlCnxStringBuilder = new SqlConnectionStringBuilder();

        //        var settings = OrderForm.Properties.Settings.Default;

        //        //sqlCnxStringBuilder.InitialCatalog = settings.InitialCatalog;
        //        sqlCnxStringBuilder.DataSource = settings.DataSource;
        //        sqlCnxStringBuilder.UserID = settings.Userid;
        //        sqlCnxStringBuilder.Password = settings.Password;
        //        //sqlCnxStringBuilder.IntegratedSecurity = settings.IntegratedSecurity;

        //        return sqlCnxStringBuilder.ConnectionString;
        //    }

        //}

    }
}