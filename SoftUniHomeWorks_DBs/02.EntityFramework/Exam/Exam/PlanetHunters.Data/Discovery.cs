using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Data
{
    public class Discovery
    {
        public Discovery()
        {
            this.Stars = new List<Star>();
            this.Planets = new List<Planet>();
            this.Pioneers = new List<Astronomer>();
            this.Observers = new List<Astronomer>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateMade { get; set; }

        [Required]
        public Telescope Telescope { get; set; }

        public virtual ICollection<Star> Stars { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }

        public virtual ICollection<Astronomer> Pioneers { get; set; }

        public virtual ICollection<Astronomer> Observers { get; set; }
    }
}
