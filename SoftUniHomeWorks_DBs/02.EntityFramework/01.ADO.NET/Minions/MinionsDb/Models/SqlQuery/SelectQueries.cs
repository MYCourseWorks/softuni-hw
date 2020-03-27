namespace MinionsDb
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public static class SelectQueries
    {
        public static void GetVillains(string connectionString) 
        {
            string query = "use MinionsDb\n";
            query += @"select 
	                        V.Name,
	                        count(M.Id) as MinionCount
                        from 
	                        Villains as V
	                        join MinionsVillains as MV on MV.VillainId = V.Id
	                        join Minions as M on M.Id = MV.MinionId
                        group by
	                        V.Name
                        order by
	                        MinionCount desc";

            QueryHooks.ExecSelectQuery(connectionString, query, (SqlDataReader reader) => 
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + " " + reader.GetInt32(1));
                }
            });
        }

        public static void GetMinionNames(string connectionString)
        {
            Console.Write("Give me a villan Id : ");
            string input = Console.ReadLine();
            int id = int.Parse(input);
            bool villainExists = true;

            string query = "use MinionsDb\n";
            query += "select Name from Villains where Id =" + id;

            QueryHooks.ExecSelectQuery(connectionString, query, (SqlDataReader reader) =>
            {
                if (reader.HasRows == false)
                {
                    Console.WriteLine("No villain with ID {0} exists in the database.", id);
                    villainExists = false;
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine("Villain: " + reader.GetString(0));
                }
            });

            if (!villainExists)
                return;

            query = "use MinionsDb\n";
            query += @"select 
                        M.Name, M.Age
                    from 
	                    Villains as V
	                    join MinionsVillains as MV on MV.VillainId = V.Id
	                    join Minions as M on M.Id = MV.MinionId
                    where 
	                    V.Id = " + id;

            QueryHooks.ExecSelectQuery(connectionString, query, (SqlDataReader reader) =>
            {
                if (reader.HasRows == false)
                {
                    Console.WriteLine("(no minions)");
                    return;
                }

                int i = 1;
                while (reader.Read())
                {
                    Console.WriteLine("{0}. {1} {2}", i++, reader.GetString(0), reader.GetInt32(1));
                }
            });
        }

        public static void PrintAllMinionNames(string connectionString)
        {
            string query = "use MinionsDb\n";
            query += @"select * from Minions";

            List<string> minions = new List<string>();
            QueryHooks.ExecSelectQuery(connectionString, query, (reader) =>
            {
                while (reader.Read())
                {
                    minions.Add(reader.GetString(2));
                }
            });

            Console.WriteLine("Before :");
            Console.WriteLine(String.Join<string>(", ", minions));

            string[] result = new string[minions.Count];
            int i = 0;
            int first = 0;
            int last = minions.Count - 1;

            while (i < minions.Count)
            {
                if (i % 2 == 0)
                {
                    result[first] = minions[i];
                    first++;
                }
                else
                {
                    result[last] = minions[i];
                    last--;
                }

                i++;
            }

            Console.WriteLine("After :");
            Console.WriteLine(String.Join(", ", result));
        }

        public static void IncreaseMinionAge(string connectionString)
        {
            Console.WriteLine("Give me Ids : ");
            int[] ids = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            string query = "use MinionsDb\n";
            query += @"select * from Minions";

            QueryHooks.ExecSelectQuery(connectionString, query, (reader) => 
            {
                while (reader.Read())
                {
                    int currId = reader.GetInt32(0);
                    int age = reader.GetInt32(1);
                    string[] names = reader
                        .GetString(2)
                        .Split(' ')
                        .Select((x) =>
                        {
                            var arr = x.ToCharArray();
                            arr[0] = Char.ToUpper(arr[0]);
                            return String.Join("", arr);
                        })
                        .ToArray();
                    
                    string nameUpper = String.Join(" ", names).Trim();

                    if (ids.Contains(currId))
                    {
                        string updateQuery = "use MinionsDb\n";
                        updateQuery += string.Format("update Minions set Name = '{0}', Age = {1} where Id = {2}", 
                            nameUpper, age + 1, currId);
                        QueryHooks.ExecTSQLQuery(connectionString, updateQuery);
                    }
                }
            });

            QueryHooks.ExecSelectQuery(connectionString, query, (reader) =>
            {
                while (reader.Read())
                {
                    int age = reader.GetInt32(1);
                    string name = reader.GetString(2);

                    Console.WriteLine("{0} {1}", name, age);
                }
            });
        }
    }
}
