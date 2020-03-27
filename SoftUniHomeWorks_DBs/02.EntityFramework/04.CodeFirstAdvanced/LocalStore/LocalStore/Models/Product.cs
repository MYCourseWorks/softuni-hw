using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalStore.Models
{
    public class Product
    {
        public Product()
        {
            this.SalesOfProducts = new List<Sale>();
            this.Description = "No description";
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double? Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Sale> SalesOfProducts { get; set; }

        public string Description { get; set; }
    }
}
