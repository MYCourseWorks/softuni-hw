using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Data
{
    public class Star
    {
        private int temperature;

        public Star()
        {
            this.temperature = 0;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Star.Name Length must be in [0-255]")]
        public string Name { get; set; }

        [Required]
        public int Temperature
        {
            get { return this.temperature; }
            set
            {
                if (value <= 2400)
                    throw new ArgumentException("Star.Temperature must be in [2400-int.Max] kelvins");

                this.temperature = value;
            }
        }

        [Required]
        public StarSystem HostStarSystem { get; set; }
    }
}
