using BibliotekaKlas.Classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekaKlas.Classes
{
    public class Transakcja : Dzialanie<int>
    {
        [Required]
        public int AccountId { get; set; }

        [Required]
        public int ATMId { get; set; }
    }
}
