using System.ComponentModel.DataAnnotations;

namespace BankSystem.Data.Models
{
    public class UserSession
    {
        public int Id { get; set; }

        [Required]
        public User User { get; set; }
    }
}
