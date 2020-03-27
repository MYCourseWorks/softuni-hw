using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Data
{
    public class Planet
    {
        private double mass;

        public Planet()
        {
            this.mass = 0;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Planet.Name Length must be in [0-255]")]
        public string Name { get; set; }

        [Required]
        public double Mass
        {
            get { return this.mass; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Planet.Mass must be in [1-double.Max]");

                this.mass = value;
            }
        }

        [Required]
        public StarSystem HostStarSystem { get; set; }
    }
}
