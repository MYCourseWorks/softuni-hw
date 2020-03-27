using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Data
{
    public class Invitation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public User InvitedUser { get; set; }

        public int? InvitedUserId { get; set; }

        public Team Team { get; set; }

        public int? TeamId { get; set; }

        public bool IsActive { get; set; }
    }
}
