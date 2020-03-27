using System;
using System.Data.Entity;

namespace PlanetHunters.Data.Provider
{
    public class DbUtil
    {
        public static void ExecTransaction(DbContext context)
        {
            var tran = context.Database.BeginTransaction();

            try
            {
                context.SaveChanges();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw e;
            }
        }
    }
}
