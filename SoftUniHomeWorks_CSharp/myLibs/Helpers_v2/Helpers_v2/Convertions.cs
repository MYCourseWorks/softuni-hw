namespace Helpers_v2
{
    using System;

    public static class Convertions
    {
        public static int HexToDecimal(string number)
        {
            return Convert.ToInt32(number, 16);
        }

        public static int BinToDecimal(string number)
        {
            return Convert.ToInt32(number, 2);
        }

        public static int OctalToDecimal(string number)
        {
            return Convert.ToInt32(number, 8);
        }
    }
}
