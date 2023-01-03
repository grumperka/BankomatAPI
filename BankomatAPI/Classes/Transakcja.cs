using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankomatAPI.Classes
{
    public class Transakcja
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        public int ATMId { get; set; }
    }
}
