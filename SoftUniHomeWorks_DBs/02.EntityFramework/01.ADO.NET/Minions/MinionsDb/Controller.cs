namespace MinionsDb
{
    public class Controller
    {

        // Task 1 :
        public void InitializeDb() 
        {
            if (CreationQueries.CheckDatabaseExists(Constants.ConnectionString, Constants.DbName))
                CreationQueries.DropDatabase(Constants.ConnectionString, Constants.DbName);

            CreationQueries.CreateDatabase(Constants.ConnectionString, Constants.DbName);
            CreationQueries.CreateMinionTables(Constants.ConnectionString);

            InsertionQueries.InsertIntoTowns(Constants.ConnectionString, "Sofia", "Bulgaria");
            InsertionQueries.InsertIntoTowns(Constants.ConnectionString, "New York", "USA");
            InsertionQueries.InsertIntoTowns(Constants.ConnectionString, "London", "UK");
            InsertionQueries.InsertIntoTowns(Constants.ConnectionString, "Brasil", "Brasil");
            InsertionQueries.InsertIntoTowns(Constants.ConnectionString, "Sydney", "Australia");

            InsertionQueries.InsertIntoMinions(Constants.ConnectionString, 13, "Bob", 1);
            InsertionQueries.InsertIntoMinions(Constants.ConnectionString, 20, "Sam", 2);
            InsertionQueries.InsertIntoMinions(Constants.ConnectionString, 14, "Kevin", 3);
            InsertionQueries.InsertIntoMinions(Constants.ConnectionString, 19, "Steward", 3);
            InsertionQueries.InsertIntoMinions(Constants.ConnectionString, 22, "Simon", 4);

            InsertionQueries.InsertIntoVillains(Constants.ConnectionString, "Gru", "evil");
            InsertionQueries.InsertIntoVillains(Constants.ConnectionString, "Victor Jr.", "good");
            InsertionQueries.InsertIntoVillains(Constants.ConnectionString, "Victor", "evil");
            InsertionQueries.InsertIntoVillains(Constants.ConnectionString, "Poppy", "super evil");

            // Gru's minions :
            InsertionQueries.InsertIntoMinionsVillains(Constants.ConnectionString, 1, 1);
            InsertionQueries.InsertIntoMinionsVillains(Constants.ConnectionString, 3, 1);
            InsertionQueries.InsertIntoMinionsVillains(Constants.ConnectionString, 4, 1);
            InsertionQueries.InsertIntoMinionsVillains(Constants.ConnectionString, 2, 1);
            InsertionQueries.InsertIntoMinionsVillains(Constants.ConnectionString, 5, 1);
            // Victor's minions :
            InsertionQueries.InsertIntoMinionsVillains(Constants.ConnectionString, 1, 3);
            InsertionQueries.InsertIntoMinionsVillains(Constants.ConnectionString, 5, 3);
            InsertionQueries.InsertIntoMinionsVillains(Constants.ConnectionString, 2, 3);
            InsertionQueries.InsertIntoMinionsVillains(Constants.ConnectionString, 4, 3);
            // Poppy's minions :
            InsertionQueries.InsertIntoMinionsVillains(Constants.ConnectionString, 2, 4);
        }

        // Task 2 :
        public void GetVillains() 
        {
            SelectQueries.GetVillains(Constants.ConnectionString);
        }

        // Task 3 :
        public void GetMinionNames()
        {
            SelectQueries.GetMinionNames(Constants.ConnectionString);
        }

        // Task 4 :
        public void AddMinions() 
        {
            CombinedQueries.AddMinion(Constants.ConnectionString);
        }

        // Task 5 :
        public void TownNamesToUpper()
        {
            CombinedQueries.TownsUpper(Constants.ConnectionString);
        }

        // Task 7 :
        public void PrintAllMinionNames() 
        {
            SelectQueries.PrintAllMinionNames(Constants.ConnectionString);
        }

        // Task 8 :
        public void IncreaseMinionAge()
        {
            SelectQueries.IncreaseMinionAge(Constants.ConnectionString);
        }

        // Task 9 :
        public void StoredProc()
        {
            CombinedQueries.StoredProc(Constants.ConnectionString);
        }
    }
}
