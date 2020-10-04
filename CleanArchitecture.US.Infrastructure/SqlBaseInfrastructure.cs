using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CleanArchitecture.US.Infrastructure
{
    public abstract class SqlBaseInfrastructure
    {

        protected SqlBaseInfrastructure(IConfiguration configuration, ILogger logger)
        {
            this.Configuration = configuration;
            this.ConnectioName = "DefaultConnectionString";
            ConnectionStrings = new Dictionary<string, string>() {
                { "DefaultConnectionString",  this.Configuration.GetConnectionString("DefaultConnectionString")}
            };

            this.Logger = logger;

            //this.Logger?.LogEnterConstructor(this.GetType());
        }
        protected SqlBaseInfrastructure(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.ConnectioName = "DefaultConnectionString";
            ConnectionStrings = new Dictionary<string, string>() {
                { "DefaultConnectionString",  this.Configuration.GetConnectionString("DefaultConnectionString")}
            };
        }
        protected IConfiguration Configuration { get; }
        public ILogger Logger { get; }
       
        protected string DefaultConnection;

        protected static Dictionary<string, string> ConnectionStrings;
        public string ConnectioName { get; set; }

        protected string GetConnectionString()
        {
            return ConnectionStrings[ConnectioName];
        }

        /// <summary>
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandName"></param>
        /// <param name="useStoredProcedure"></param>
        /// <returns></returns>
        public SqlCommand GetSqlCommand(string connectionString, string commandName, bool useStoredProcedure)
        {
            var conn = new SqlConnection(connectionString);
            return GetSqlCommand(conn, commandName, useStoredProcedure);
        }


        /// <summary>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commandName"></param>
        /// <param name="useStoredProcedure"></param>
        /// <returns></returns>
        public SqlCommand GetSqlCommand(SqlConnection connection, string commandName, bool useStoredProcedure)
        {
            var cmd = new SqlCommand(commandName, connection)
            {
                CommandType = useStoredProcedure ? CommandType.StoredProcedure : CommandType.Text,
                //CommandTimeout = ConfigurationReader.GetDefaultCommandTimeOutDuration()
                CommandTimeout = 9999
            };
            return cmd;
        }

        /// <summary>
        /// Get Connection
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            return GetConnection(GetConnectionString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static SqlConnection GetConnection(string connectionString)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SqlParameter GetInParameter(string paramName, SqlDbType dbType, object value)
        {
            var param = new SqlParameter(paramName, dbType) { Value = value };
            return param;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static SqlParameter GetOutParameter(string paramName, SqlDbType dbType)
        {
            var param = new SqlParameter(paramName, dbType) { Direction = ParameterDirection.Output };
            return param;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SqlParameter GetOutParameter(string paramName, SqlDbType dbType, object value)
        {
            var param = new SqlParameter(paramName, dbType)
            {
                Value = value,
                Direction = ParameterDirection.InputOutput
            };
            return param;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static async Task<SqlDataReader> ExecuteReaderAsync(SqlCommand command)
        {
            var results =  await command.ExecuteReaderAsync();
            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static async Task<object> ExecuteScalarAsync(SqlCommand command)
        {
            var result = await command.ExecuteScalarAsync();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static async Task<int> ExecuteNonQueryAsync(SqlCommand command)
        {
           return await command.ExecuteNonQueryAsync();
        }
    }
}
