using System;

namespace User
{
    class Program
    {
        static void Main(string[] args)
        {
            UserContext ctx = new UserContext();
            ctx.Database.Delete();
            ctx.Database.Create();

            var pesho = new User()
            {
                Username = "Pesho",
                Password = "Peshev,23",
                Email = "pesho@mail.bg"
            };

            var gosho = new User()
            {
                Username = "Pesho",
                Password = "Peshev,23",
                Email = "pesho@mail.bg",
                RegisteredOn = DateTime.Now,
                IsDeleted = true
            };

            var tran = ctx.Database.BeginTransaction();

            try
            {
                ctx.Users.Add(pesho);
                ctx.Users.Add(gosho);
                ctx.SaveChanges();
                tran.Commit();
                Console.WriteLine("Nishto ne grumna.");
            }
            catch (Exception)
            {
                tran.Rollback();
                Console.Error.Write("Nesto grumna!");
            }
        }
    }
}
