using System;
using System.Data.Entity;

namespace JSON_Processing.Global
{
    public static class DbOperationExtentions
    {
        public static void ExecTranOnContext(DbContext context, string errorMessage)
        {
            var tran = context.Database.BeginTransaction();

            try
            {
                context.SaveChanges();
                tran.Commit();
            }
            catch (Exception)
            {
                tran.Rollback();
                throw new Exception(errorMessage);
            }
        }
    }
}
