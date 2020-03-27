using BankSystem.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public RoleEnum Role { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
