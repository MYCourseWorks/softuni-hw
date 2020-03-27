namespace MinionsDb
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public static class CombinedQueries
    {
        public static void AddMinion(string connectionString) 
        {
            Console.Write("Give me input :");
            
            string input = Console.ReadLine();
            string[] spliInput = input.Split(' ');
            string minionName = spliInput[1];
            int minionAge = int.Parse(spliInput[2]);
            string minionTown = spliInput[3];
            
            input = Console.ReadLine();
            spliInput = input.Split(' ');
            string villainName = spliInput[1];

            string query = "use MinionsDb\n";
            query += @"select * from Towns where TownName = '" + minionTown + "'";
            QueryHooks.ExecSelectQuery(connectionString, query, (reader) => 
            {
                if (reader.HasRows == false)
                {
                    Console.WriteLine("Town {0} was added to the database.", minionTown);
                    InsertionQueries.InsertIntoTowns(connectionString, minionTown, null);
                    return;
                }
            });

            int minionTownId = 0;
            QueryHooks.ExecSelectQuery(connectionString, query, (reader) =>
            {
                while (reader.Read())
                {
                    minionTownId = reader.GetInt32(0);
                }
            });

            query = "use MinionsDb\n";
            query += @"select * from Villains where Name = '" + villainName + "'";
            QueryHooks.ExecSelectQuery(connectionString, query, (reader) =>
            {
                if (reader.HasRows == false)
                {
                    Console.WriteLine("Villain {0} was added to the database.", villainName);
                    InsertionQueries.InsertIntoVillains(connectionString, villainName, "evil");
                    return;
                }
            });

            int villainId = 0;
            QueryHooks.ExecSelectQuery(connectionString, query, (reader) =>
            {
                while (reader.Read())
                {
                    villainId = reader.GetInt32(0);
                }
            });

            int minionCount = (int)QueryHooks.ExecScalarQuery(connectionString, "use MinionsDb; select count(*) from Minions");
                
            InsertionQueries.InsertIntoMinions(connectionString, minionAge, minionName, minionTownId);
            InsertionQueries.InsertIntoMinionsVillains(connectionString, minionCount + 1, villainId);
            Console.WriteLine("Successfully added {0} to be minion of {1}.", minionName, villainName);
        }

        public static void TownsUpper(string connectionString)
        {
            Console.Write("Give me country name : ");
            string countryName = Console.ReadLine();

            string query = "use MinionsDb;\n";
            query += "select * from Towns where CountryName = '" + countryName + "'";

            if (QueryHooks.IsEmptyReader(connectionString, query))
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            List<string> towns = new List<string>();
            QueryHooks.ExecSelectQuery(connectionString, query, (reader) => 
            {
                while (reader.Read())
                {
                    towns.Add(reader.GetString(1).ToUpper());
                }
            });

            query = "use MinionsDb;\n";
            query += @"update Towns
                    set TownName = UPPER(TownName)
                    where CountryName = '" + countryName + "'";

            int affectedRows = QueryHooks.ExecTSQLQuery(connectionString, query);
            Console.WriteLine("{0} town names were affected.", affectedRows);
            Console.WriteLine( '[' + string.Join<string>(",", towns) + ']');
        }

        public static void StoredProc(string connectionString)
        {
            Console.Write("Give me id : ");
            int minionId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(
                    @"Server=.\SQLEXPRESS;
                    database=MinionsDb;
                    Integrated Security=true");
            SqlCommand command = new SqlCommand();
            int affected = 0;

            using (connection)
            using (command)
            {
                connection.Open();

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@MinionId", SqlDbType.Int));
                command.Parameters[0].Value = minionId;
                command.Connection = connection;
                command.CommandText = "usp_GetOlder";

                affected = command.ExecuteNonQuery();
            }

            string query = "use MinionsDb\n";
            query += "select * from Minions";

            QueryHooks.ExecSelectQuery(connectionString, query, (reader) => 
            {
                while (reader.Read())
                {
                    int age = reader.GetInt32(1);
                    string name = reader.GetString(2);
                    Console.WriteLine("{0} {1}", age, name);
                }
            });
        }
    }
}
