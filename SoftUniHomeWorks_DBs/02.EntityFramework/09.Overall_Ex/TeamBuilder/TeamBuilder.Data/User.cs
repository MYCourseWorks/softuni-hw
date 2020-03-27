using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeamBuilder.Data.Enums;

namespace TeamBuilder.Data
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Username must be in [3-25]")]
        public string Username { get; set; }

        [StringLength(25)]
        public string FirstName { get; set; }

        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Username must be in [6-30]")]
        public string Password { get; set; }

        public Gender? Gender { get; set; }

        public int? Age { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<Team> CreatedTeams { get; set; }

        public virtual ICollection<Event> CreatedEvents { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
