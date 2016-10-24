using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For.SSO.DB.Models
{
    public static class DBConfiguration
    {

        private static string _metaData;
        private static string _serverName;
        private static string _databaseName;
        private static string _providerName;
        private static string _userId;
        private static string _password;

        public static void SetDBConnectionProperty(string metaData, string serverName, string databaseName, string providerName, string userId, string password)
        {
            _metaData = metaData;
            _serverName = serverName;
            _databaseName = databaseName;
            _providerName = providerName;
            _userId = userId;
            _password = password;
        }

        public static EntityConnection GetDBConnection()
        {
            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
            new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = _serverName;
            sqlBuilder.InitialCatalog = _databaseName;
            sqlBuilder.IntegratedSecurity = false;
            sqlBuilder.MultipleActiveResultSets = true;
            sqlBuilder.PersistSecurityInfo = true;
            sqlBuilder.ApplicationName = "EntityFrameWork";
            sqlBuilder.UserID = _userId;
            sqlBuilder.Password = _password;

            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
            new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = _providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            //metadata=;provider=System.Data.SqlClient;provider connection string=&quot;data source=192.168.137.1\SQLExpress;initial catalog=SSO;persist security info=True;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient"

            // Set the Metadata location.
            entityBuilder.Metadata = _metaData;

            EntityConnection conn =
            new EntityConnection(entityBuilder.ToString());
            return conn;
        }
    }
}
