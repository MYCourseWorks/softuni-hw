using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalStore.Models
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Product Product { get; set; }

        public Customer Customer { get; set; }

        public StoreLocation StoreLocation { get; set; }

        public DateTime? Date { get; set; }
    }
}
