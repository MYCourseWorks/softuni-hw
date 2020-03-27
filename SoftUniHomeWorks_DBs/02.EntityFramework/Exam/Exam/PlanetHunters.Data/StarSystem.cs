using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanetHunters.Data
{
    public class StarSystem
    {
        public StarSystem()
        {
            this.Planets = new List<Planet>();
            this.Stars = new List<Star>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "StarSystem.Name Length must be in [0-255]")]
        public string Name { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }

        public virtual ICollection<Star> Stars { get; set; }
    }
}
