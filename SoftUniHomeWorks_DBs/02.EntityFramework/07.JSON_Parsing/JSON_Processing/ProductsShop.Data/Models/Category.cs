using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsShop.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Category.Name must be between 3 and 15 symbols")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
