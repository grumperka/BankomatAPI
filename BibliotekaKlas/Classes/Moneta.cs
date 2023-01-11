using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas.Classes
{
    public class Moneta : Pieniadz<double>
    {
        /*
        [Key]
        public int Id { get; set; }

        [Required]
        public double Value { get; set; }

        public int? WalletId { get; set; }
        public virtual Portfel Wallet { get; set; }*/

        public int? VendingMachineId { get; set; }
        public virtual Automat VendingMachine { get; set; }

        public Moneta(double value) {

            if (this.isValue(value))
            {
                this.Value = value;
            }
            else 
            {
                throw new ArgumentOutOfRangeException("Nieprawidłowa wartość monety");
            }
        }

        public override bool isValue(double value){

            if (value == 0.01 || value == 0.02 || value == 0.05 || value == 0.1 || value == 0.2 || value == 0.5 || value == 1.0 || value == 2.0 || value == 5.0)
            {
                return true;
            }
            else return false;
        }
    }
}
