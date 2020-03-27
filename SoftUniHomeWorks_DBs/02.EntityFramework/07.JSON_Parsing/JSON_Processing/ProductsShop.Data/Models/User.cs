using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsShop.Data.Models
{
    public class User
    {
        public User()
        {
            this.SoldProducts = new List<Product>();
            this.BoughtProducts = new List<Product>();
            this.Friends = new List<User>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public virtual ICollection<Product> SoldProducts { get; set; }

        public virtual ICollection<Product> BoughtProducts { get; set; }

        public virtual ICollection<User> Friends { get; set; }
    }
}