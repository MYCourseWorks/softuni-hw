using System;
using System.Text;

namespace BankSystem.Services
{
    public static class RndGenService
    {
        private static Random rnd = new Random();

        public static string RndString(int len, string domainSet)
        {
            if (domainSet == null)
                return "";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                int rndNum = rnd.Next(0, domainSet.Length - 1);
                sb.Append(domainSet[rndNum]);
            }

            return sb.ToString();
        }
    }
}
