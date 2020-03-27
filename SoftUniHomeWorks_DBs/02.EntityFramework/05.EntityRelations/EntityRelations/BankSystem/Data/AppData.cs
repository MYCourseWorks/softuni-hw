namespace BankSystem.Data
{
    public static class AppData
    {
        private static BankSystemContext ctx;

        public static BankSystemContext BankSystemContext
        {
            get
            {
                return ctx != null ? ctx : ctx = new BankSystemContext();
            }
        }
    }
}
