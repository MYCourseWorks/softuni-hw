namespace Helpers_v2.Extentions
{
    using System;

    public static class ConvertionExtentions
    {
        public static string ToHex(this int number)
        {
            return Convert.ToString(number, 16);
        }

        public static string ToBinary(this int number)
        {
            return Convert.ToString(number, 2);
        }

        public static string ToOctal(this int number)
        {
            return Convert.ToString(number, 8);
        }
    }
}
