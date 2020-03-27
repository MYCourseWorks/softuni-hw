using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalStore.Models
{
    public class Customer
    {
        public Customer()
        {
            this.SalesForCustomer = new List<Sale>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [DataType(DataType.CreditCard)]
        public string CrediCardNumber { get; set; }

        public virtual ICollection<Sale> SalesForCustomer { get; set; }
    }
}
