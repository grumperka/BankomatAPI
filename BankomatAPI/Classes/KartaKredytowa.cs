using System.ComponentModel.DataAnnotations;

namespace BankomatAPI.Classes
{
    public class KartaKredytowa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PIN { get; set; }

        [Required]
        public int AccountId { get; set; }

        public virtual Konto Account { get; set; }
    }
}
