using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalStore.Models
{
    public class StoreLocation
    {
        public StoreLocation()
        {
            this.SalesInStore = new List<Sale>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string LocationName { get; set; }

        public virtual ICollection<Sale> SalesInStore { get; set; }
    }
}
