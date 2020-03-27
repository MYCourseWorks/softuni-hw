using System.Xml.Serialization;

namespace PlanetHunter.DTO
{
    [XmlRoot("Star")]
    public class StarDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Temperature")]
        public int Temperature { get; set; }

        [XmlElement("StarSystem")]
        public string StarSystem { get; set; }
    }
}
