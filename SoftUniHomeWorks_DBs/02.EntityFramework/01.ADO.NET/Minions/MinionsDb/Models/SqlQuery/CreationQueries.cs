namespace MinionsDb
{
    using System;
    using System.IO;
    using System.Data.SqlClient;

    public static class CreationQueries
    {
        public static bool CheckDatabaseExists(string connectionString, string databaseName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(string.Format("select db_id('{0}')", databaseName), connection))
                {
                    connection.Open();
                    return (command.ExecuteScalar() != DBNull.Value);
                }
            }
        }

        public static void CreateDatabase(string connectionString, string databaseName)
        {
            QueryHooks.ExecTSQLQuery(connectionString, string.Format("create database {0}", databaseName));
        }

        public static void DropDatabase(string connectionString, string databaseName)
        {
            var dropQuery = "alter database " + databaseName + " set single_user with rollback immediate\n";
            dropQuery += "drop database " + databaseName;
            QueryHooks.ExecTSQLQuery(connectionString, dropQuery);
        }

        public static void CreateMinionTables(string connectionString) 
        {
            string createTablesQuery = File.ReadAllText(Constants.CreateTablesSql);
            QueryHooks.ExecTSQLQuery(connectionString, createTablesQuery);
        }

        public static void DropMinionTables(string connectionString)
        {
            string dropTablesQuery = File.ReadAllText(Constants.DropTablesSql);
            QueryHooks.ExecTSQLQuery(connectionString, dropTablesQuery);
        }
    }
}
