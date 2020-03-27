using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlanetHuner.Import
{
    internal static class JsonFileOperations
    {
        private static readonly JsonSerializerSettings defaultSettings = new JsonSerializerSettings()
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            Formatting = Formatting.Indented
        };

        public static ICollection<T> DeserializeJsonCollection<T>(string path)
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
            //WriteToOutDir(Constants.OutDirectory, ConvertClassNameToJsonName(taskType), rawJson);
        }

        private static void WriteToOutDir(string outDir, string fileName, string data)
        {
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            File.WriteAllText(outDir + fileName, data);
        }
    }
}
