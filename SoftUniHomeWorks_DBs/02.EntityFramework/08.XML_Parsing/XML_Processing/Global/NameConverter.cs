using System;
using System.Text;

namespace Global
{
    public static class NameConverter
    {
        public static string ConvertClassNameToSnakeCase(Type type, string fileExtention)
        {
            string typeName = type.Name;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < typeName.Length; i++)
            {
                char curr = typeName[i];

                if (char.IsUpper(curr) && i != 0)
                    sb.Append('-');

                sb.Append(char.ToLower(curr));
            }

            sb.Append(fileExtention);
            return sb.ToString();
        }
    }
}
