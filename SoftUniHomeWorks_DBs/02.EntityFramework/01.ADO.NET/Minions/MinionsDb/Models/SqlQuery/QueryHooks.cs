namespace MinionsDb
{
    using System;
    using System.Data.SqlClient;

    public class QueryHooks
    {
        public static int ExecTSQLQuery(string connectionString, string query)
        {
            int ret;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    ret = command.ExecuteNonQuery();
                }
            }

            return ret;
        }

        public static void ExecSelectQuery(string connectionString, string selectQuery, Action<SqlDataReader> callback)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    callback(reader);
                }
            }
        }

        public static object ExecScalarQuery(string connectionString, string scalarQuery)
        {
            object ret;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(scalarQuery, connection))
                {
                    connection.Open();
                    ret = command.ExecuteScalar();
                }
            }

            return ret;
        }

        public static bool IsEmptyReader(string connectionString, string query)
        {
            bool ret = false;

            QueryHooks.ExecSelectQuery(connectionString, query, (reader) =>
            {
                if (reader.HasRows == false)
                    ret = true;
            });

            return ret;
        }
    }
}
