using System.ComponentModel.DataAnnotations;

namespace BibliotekaKlas.Classes
{
    public class Konto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Balance { get; set; }

        [Required]
        public int OwnerId { get; set; }

        public virtual Wlasciciel Owner { get; set; }

        public List<Banknot>? DeposingOperation(List<Banknot> banknots) {

            if (banknots != null)
            {
                if (banknots.Any()) { 
                    foreach (Banknot banknot in banknots)
                    {
                        if (banknot.isValue(banknot.Value) == true)
                        {
                            this.Balance += banknot.Value;
                            banknot.WalletId = null;
                        } 
                        else return null;
                    }

                    return banknots;
                }
                else return null;
            }
            else return null;
        }

        public bool isEnough(double value) {

            if (this.Balance >= value)
            {
                return true;
            }
            else return false;

        }

        public bool WithdrawingOperation(double value) {

            if (this.isEnough(value))
            {
                this.Balance -= value;
                return true;
            }
            return false;
        
        }

        public bool TransferOperation(double value)
        {
            if (value > 0)
            {
                this.Balance += value;
                return true;
            }
            else return false;
            
        }


    }
}
