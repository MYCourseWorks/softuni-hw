using System;
using System.ComponentModel;

namespace TeamBuilder.App.Extensions
{
    public static class StringValidations
    {
        public static bool IsNumber(this string str)
        {
            int tmp = 0;
            return int.TryParse(str, out tmp);
        }

        public static bool IsGender(this string str)
        {
            string lower = str.ToLower();
            return lower == "male" | lower == "female";
        }

        public static bool CanConvertTo(this string str, Type type)
        {
            var converter = TypeDescriptor.GetConverter(typeof(string));
            return converter.CanConvertTo(type);
        }
    }
}
