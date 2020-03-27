namespace MinionsDb
{
    public static class InsertionQueries
    {
        public static void InsertIntoTowns(string connectionString, string TownName, string CountryName)
        {
            string query = "use MinionsDb\n";
            query += "insert into Towns values('" + TownName + "', '" + CountryName + "')";
            QueryHooks.ExecTSQLQuery(connectionString, query);
        }

        public static void InsertIntoMinions(string connectionString, int Age, string Name, int TownId)
        {
            string query = "use MinionsDb\n";
            query += "insert into Minions values(" + Age + ", '" + Name + "', " + TownId + ")";
            QueryHooks.ExecTSQLQuery(connectionString, query);
        }

        public static void InsertIntoVillains(string connectionString, string Name, string EvilnessFactor)
        {
            string query = "use MinionsDb\n";
            query += "insert into Villains values('" + Name + "', '" + EvilnessFactor + "')";
            QueryHooks.ExecTSQLQuery(connectionString, query);
        }

        public static void InsertIntoMinionsVillains(string connectionString, int MinionId, int VillainId)
        {
            string query = "use MinionsDb\n";
            query += "insert into MinionsVillains values(" + MinionId + ", " + VillainId + ")";
            QueryHooks.ExecTSQLQuery(connectionString, query);
        }
    }
}
