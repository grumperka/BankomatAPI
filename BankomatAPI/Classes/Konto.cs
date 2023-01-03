using System.ComponentModel.DataAnnotations;

namespace BankomatAPI.Classes
{
    public class Konto: AbstractBanknoty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public long Balance { get; set; }

        [Required]
        public int OwnerId { get; set; }

        public virtual Wlasciciel Owner { get; set; }

        public List<Banknot>? DeposingOperation(List<Banknot> banknots) {

            if (banknots != null)
            {
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

        public bool isEnough(int value) {

            if (this.Balance >= value)
            {
                return true;
            }
            else return false;

        }

        public bool WithdrawingOperation(int value) {

            if (this.isEnough(value))
            {
                this.Balance -= value;
                return true;
            }
            return false;
        
        }
    }
}
