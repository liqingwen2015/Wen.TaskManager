#region

using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

#endregion

namespace Wen.TaskManager.DAL
{
    internal class DbConnectionFactory
    {
        private static readonly string ConnectionString;
        private static readonly string ProviderName;

        static DbConnectionFactory()
        {
            var collection = ConfigurationManager.ConnectionStrings["TaskManagerConnectionString"];
            ConnectionString = collection.ConnectionString;
            ProviderName = collection.ProviderName;
        }

        /// <summary>
        /// 创建 Db 连接对象
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateDbConnection()
        {
            IDbConnection connection = null;

            switch (ProviderName)
            {
                case "system.data.sqlclient":
                    connection = new SqlConnection(ConnectionString);
                    break;
                case "mysql":
                    //connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    break;
                case "oracle":
                    //connection = new Oracle.DataAccess.Client.OracleConnection(connectionString);
                    //connection = new System.Data.OracleClient.OracleConnection(connectionString);
                    break;
                case "db2":
                    connection = new OleDbConnection(ConnectionString);
                    break;
                default:
                    connection = new SqlConnection(ConnectionString);
                    break;
            }

            return connection;
        }
    }
}