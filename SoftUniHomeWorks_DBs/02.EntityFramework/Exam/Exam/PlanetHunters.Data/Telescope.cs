using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Data
{
    public class Telescope
    {
        private double? mirrorDiameter;

        public Telescope()
        {
            this.mirrorDiameter = null;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Telescope.Name Length must be in [0-255]")]
        public string Name { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Telescope.Location Length must be in [0-255]")]
        public string Location { get; set; }

        public double? MirrorDiameter
        {
            get { return this.mirrorDiameter; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Telescope.MirrorDiameter must be in [1-double.Max]");

                this.mirrorDiameter = value;
            }
        }
    }
}
