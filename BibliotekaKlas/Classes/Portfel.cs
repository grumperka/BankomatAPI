using BibliotekaKlas.Classes;
using System.ComponentModel.DataAnnotations;

namespace BibliotekaKlas.Classes
{
    public class Portfel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OwnerId { get; set; }

        public virtual Wlasciciel Owner { get; set; }

        [Required]
        public double Sum { get; set; }

        public virtual ICollection<Banknot> BanknotsList { get; set; }

        public virtual ICollection<Moneta> MonetasList { get; set; }

        /*
        public Portfel(Wlasciciel owner) { 

            this.Owner = owner;
            this.Sum = 0;

        }*/


        public bool isEnough(double value)
        {
            if (this.Sum >= value) { return true; }
            else { return false; }
        }

        public bool addBanknot(Banknot banknot) {

            if (banknot.isValue(banknot.Value) == true)
            {
                banknot.ATMId = null;
                banknot.WalletId = this.Id;
                this.BanknotsList.Add(banknot);
                this.Sum += banknot.Value;
                return true;
            }
            else return false; 

        }

        public Banknot? removeBanknot(Banknot banknot) {

            if (banknot.isValue(banknot.Value) == true && BanknotsList.Where(b => b.Value == banknot.Value).Any() == true)
            {
                banknot.WalletId = null;
                this.BanknotsList.Remove(banknot);
                this.Sum -= banknot.Value;
                return banknot;
            }
            else return null;

        }

        public List<Banknot> AddRange(List<Banknot> banknots) {

            List<Banknot> errors = new List<Banknot>();

            foreach (Banknot banknot in banknots) {

                if (banknot.isValue(banknot.Value) == true) { this.addBanknot(banknot); }
                else errors.Add(banknot);
                
            }

            if(errors.Any()) return errors;

            return errors;
        }

        public int getBanknotsCount(int nominal)
        {
            return BanknotsList.Where(w => w.Value == nominal).ToList().Count;
        }

        public int getMonetasCount(double nominal)
        {
            return MonetasList.Where(w => w.Value == nominal).ToList().Count;
        }

        public List<Banknot>? GetBanknots(int value) {

            if (value % 10 == 0 || value >= 10 || this.Sum <= value)
            {
                this.BanknotsList = this.BanknotsList.OrderByDescending(b => b.Value).ToList();
                List<Banknot> banknotsList = new List<Banknot>();
                int i = 0;

                while (value != 0 || i <= this.BanknotsList.Count()) {

                    if (i >= this.BanknotsList.Count()) break;

                    var outBanknot = this.BanknotsList.ElementAt(i);

                    if (outBanknot.Value <= value)
                    {
                        int countNeeded = value / outBanknot.Value;
                        int countHowMuch = this.getBanknotsCount(outBanknot.Value);

                        int countFor = (countNeeded > countHowMuch) ? countHowMuch : countNeeded;

                        for (int j = 0; j < countFor; j++)
                        {
                            value = value - outBanknot.Value;
                            //this.BanknotsList.Remove(outBanknot);
                            banknotsList.Add(outBanknot);
                        }
                    }
                    i++;
                }

                if (value == 0) { 
                    return banknotsList; 
                }
                else return null;
            }
            else return null;

        }

        public List<Banknot>? RemoveRange(int value)
        {
            var banknots = this.GetBanknots(value);

            if (banknots == null) return null;

            foreach (Banknot banknot in banknots)
            {
                this.removeBanknot(banknot);
            }

            return banknots;
        }

    }
}
