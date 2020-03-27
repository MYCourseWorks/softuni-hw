using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;

namespace TeamBuilder.Data
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Name must be in [0-25]")]
        public string Name { get; set; }

        [StringLength(35, ErrorMessage = "Description must be in [0-35]")]
        public string Description { get; set; }

        [Required]
        public string Acronym { get; set; }

        public User Creator { get; set; }

        public int? CreatorId { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Invitation> Invitatins { get; set; }
    }
}
