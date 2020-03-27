namespace Hospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string LastName { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        [Required]
        public bool IsInshured { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }

        public virtual ICollection<Medication> PerscribedMedications { get; set; }
    }
}
