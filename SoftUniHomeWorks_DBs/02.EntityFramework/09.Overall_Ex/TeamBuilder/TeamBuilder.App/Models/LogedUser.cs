using TeamBuilder.Data;

namespace TeamBuilder.App.Models
{
    public static class LogedUser
    {
        public static User User { get; private set; }

        public static void Logout ()
        {
            User = null;
        }

        public static void Login(User u)
        {
            User = u;
        }
    }
}
