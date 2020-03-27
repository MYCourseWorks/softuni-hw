using System.Collections.Generic;

namespace PlanetHunter.DTO
{
    public class DiscoveryDto
    {
        public ICollection<StarDto> Stars { get; set; }

        public ICollection<AstronomerDto> Pioneers { get; set; }

        public ICollection<AstronomerDto> Observers { get; set; }
    }
}
