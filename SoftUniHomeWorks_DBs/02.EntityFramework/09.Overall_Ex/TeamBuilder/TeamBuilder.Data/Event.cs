using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamBuilder.Data
{
    public class Event
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 2)]
        [StringLength(25)]
        public string Name { get; set; }

        [Column(Order = 3)]
        [StringLength(250)]
        public string Description { get; set; }

        [Column(Order = 4)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy HH:mm}")]
        public DateTime? StartDate { get; set; }

        [Column(Order = 5)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy HH:mm}")]
        public DateTime? EndDate { get; set; }

        public User Creator { get; set; }

        [Column(Order = 6)]
        public int? CreatorId { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
