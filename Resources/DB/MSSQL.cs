using Resources.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Resources.DB
{
    public static class MSSQL
    {
        public static QueryResultModel GetQueryResult(string vConnectionString, string vQuery)
        {
            SqlConnection Connection;  // It is for SQL connection
            DataSet ds = new DataSet();  // it is for store query result
            QueryResultModel queryResultModel;

            try
            {
                Connection = new SqlConnection(vConnectionString);  // Declare SQL connection with connection string 
                Connection.Open();  // Connect to Database

                SqlDataAdapter adp = new SqlDataAdapter(vQuery, Connection);  // Execute query on database 
                adp.Fill(ds);  // Store query result into DataSet object   
                Connection.Close();  // Close connection 
                Connection.Dispose();   // Dispose connection             
            }
            catch (Exception ex)
            {
                queryResultModel = new QueryResultModel
                {
                    Tables = null,
                    Error = ex.Message
                };
                return queryResultModel;
            }
            queryResultModel = new QueryResultModel
            {
                Tables = ds.Tables,
                Error = null
            };

            return queryResultModel;
        }
        //public static List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map)
        //{
        //    using (var context = new DbContext(ConnectionStrings.EAGLE_TEST4))
        //    {
        //        using (var command = context.Database.GetDbConnection().CreateCommand())
        //        {
        //            command.CommandText = query;
        //            command.CommandType = CommandType.Text;

        //            context.Database.OpenConnection();

        //            using (var result = command.ExecuteReader())
        //            {
        //                var entities = new List<T>();

        //                while (result.Read())
        //                {
        //                    entities.Add(map(result));
        //                }

        //                return entities;
        //            }
        //        }
        //    }
        //}
    }
}
