using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BibliotekaKlas.Classes
{
    public class Bankomat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Banknot> BanknotsList { get; set; }


        public int getAllBanknotsSum()
        {
            return BanknotsList.Sum(w => w.Value);
        }

        public int getBanknotsCount(int nominal)
        {
            return BanknotsList.Where(w => w.Value == nominal).ToList().Count();
        }

        public List<Banknot> withdrawMoneyFromATM(int value) {

            if (value % 10 != 0 || value < 10 || this.getAllBanknotsSum() < value)
            {
                return null;
            }
            else 
            {
                int countHowMuch = 0;
                int countNeeded = 0;
                int countFor = -1;

                int[] nominals = new int[] { 10, 20, 50, 100, 200, 500 };

                int nominalsCount = 5;
                List<Banknot> banknotsList = new List<Banknot>();

                while (nominalsCount > -1) {

                    if (nominals[nominalsCount] <= value)
                    {
                        countNeeded = value / nominals[nominalsCount];
                        countHowMuch = this.getBanknotsCount(nominals[nominalsCount]);

                        countFor = (countNeeded > countHowMuch) ? countHowMuch : countNeeded;
                        
                        for (int i = 0; i < countFor; i++) { 
                            value = value - nominals[nominalsCount];
                            Banknot outBanknot = this.BanknotsList.Where(w => w.Value == nominals[nominalsCount]).First();
                            BanknotsList.Remove(outBanknot);
                            banknotsList.Add(outBanknot);
                        }
                        
                    }
                    nominalsCount--;

                }

                return banknotsList;
            }
        
        }


        public bool getBanknotsIntoATM(List<Banknot> banknots) 
        {
            if (banknots != null) {
                foreach (Banknot banknot in banknots) {
                    banknot.ATMId = this.Id;
                    banknot.WalletId = null;
                    this.BanknotsList.Add(banknot);
                }

                return true;
            } 
            else return false;
        }



    }
}
