namespace MinionsDb
{
    public static class Constants
    {
        public static readonly string ConnectionString = @"Server=.\SQLEXPRESS;Integrated Security=true";
        public static readonly string CreateTablesSql = "../../Sql/create_tables.sql";
        public static readonly string DropTablesSql = "../../Sql/drop_tables.sql";
        public static readonly string DbName = "MinionsDb";
    }
}
