namespace Gringotts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WizzardDeposits
    {
        private int age;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string LastName { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        [Required]
        public int Age {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException($"Trying to set invalid value: {value}");
                else
                    this.age = value;
            }
        }

        [StringLength(100)]
        public string MagicWandCreator { get; set; }

        [Range(1, int.MaxValue)]
        public int? MagicWandSize { get; set; }

        [StringLength(20)]
        public string DepositGroup { get; set; }

        public DateTime? DepositStartDate { get; set; }

        public decimal? DepositAmount { get; set; }

        public decimal? DepositInterest { get; set; }

        public decimal? DepositCharge { get; set; }

        public DateTime? DepositExpirationDate { get; set; }

        public bool? IsDepositExpired { get; set; }
    }
}
