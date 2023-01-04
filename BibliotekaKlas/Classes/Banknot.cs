using BibliotekaKlas.Classes;
using System.ComponentModel.DataAnnotations;

namespace BibliotekaKlas.Classes
{
    public class Banknot: Pieniadz<int>
    {
        /*
        [Key]
        public int Id { get; set; }

        [Required]
        public int Value { get; set; } */

        public int? ATMId { get; set; }

        public virtual Bankomat ATM { get; set; }

        /*
        public int? WalletId { get; set; }

        public virtual Portfel Wallet { get; set; }*/


        public Banknot(int value) {

            if (!this.isValue(value))
            {
                throw new ArgumentOutOfRangeException("Nieprawidłowa wartość banknotu");
            }
            else 
            { 
                this.Value = value; 
            }
            
        }

        public override bool isValue(int value){

            if (value == 10 || value == 20 || value == 50 || value == 100 || value == 200 || value == 500)
            {
                return true;
            }
            else return false;
        }
    }
}
