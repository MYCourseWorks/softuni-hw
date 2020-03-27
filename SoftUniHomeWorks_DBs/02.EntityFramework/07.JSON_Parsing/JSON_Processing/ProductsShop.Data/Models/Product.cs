using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsShop.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Categories = new List<Category>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int SellerId { get; set; }

        [Required]
        public virtual User Seller { get; set; }

        public int? BuyerId { get; set; }

        public virtual User Buyer { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}