using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JSON_Processing
{
    public static  class FileOperations
    {
        private static readonly JsonSerializerSettings defaultSettings = new JsonSerializerSettings()
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            Formatting = Formatting.Indented
        };

        public static ICollection<T> DeserializeJson<T>(string path)
        {
            JsonReader reader = new JsonTextReader(new StreamReader(path));
            JsonSerializer serializer = new JsonSerializer();
            T[] users = serializer.Deserialize<T[]>(reader);
            return users;
        }

        public static void WriteJson<T>(Type taskType, T obj, JsonSerializerSettings settings = null)
        {
            if (settings == null)
                settings = defaultSettings;
            
            string rawJson = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
            WriteToOutDir(Constants.OutDirectory, ConvertClassNameToJsonName(taskType), rawJson);
        }

        private static void WriteToOutDir(string outDir, string fileName, string data)
        {
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            File.WriteAllText(outDir + fileName, data);
        }

        private static string ConvertClassNameToJsonName(Type type)
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

            sb.Append(".json");
            return sb.ToString();
        }
    }
}
