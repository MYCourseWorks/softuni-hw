using System;

namespace PlanetHuner.Import
{
    public static class Constants
    {
        public static readonly string DataDirectory = "../../../PlanetHuner.Import/data/";
        public static readonly string AstronomerJsonFile = DataDirectory + "astronomers.json";
        public static readonly string PlanetJsonFile = DataDirectory + "planets.json";
        public static readonly string TelescopeJsonFile = DataDirectory + "telescopes.json";
        public static readonly string StarXmlFile = DataDirectory + "stars.xml";
        public static readonly string DiscoveryXmlFile = DataDirectory + "discoveries.xml";
        public static readonly string InvalidDataFormat = "Invalid data format.";
    }
}
