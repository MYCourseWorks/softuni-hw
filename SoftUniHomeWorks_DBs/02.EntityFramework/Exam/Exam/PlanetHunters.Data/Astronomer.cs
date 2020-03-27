using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Data
{
    public class Astronomer
    {
        public Astronomer()
        {
            this.PioneerDiscoveries = new List<Discovery>();
            this.ObservedDiscoveries = new List<Discovery>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Astronomer.Name Length must be in [0-50]")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Astronomer.Name Length must be in [0-50]")]
        public string LastName { get; set; }

        public virtual ICollection<Discovery> PioneerDiscoveries { get; set; }

        public virtual ICollection<Discovery> ObservedDiscoveries { get; set; }
    }
}
