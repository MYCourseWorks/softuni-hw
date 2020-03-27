namespace Hospital.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Visitation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime VisitationDate { get; set; }

        [StringLength(1000000)]
        public string Comments { get; set; }
    }
}
