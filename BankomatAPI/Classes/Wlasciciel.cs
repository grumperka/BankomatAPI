using System.ComponentModel.DataAnnotations;

namespace BankomatAPI.Classes
{
    public class Wlasciciel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public List<Portfel> WalletsList { get; set; }
    }
}
