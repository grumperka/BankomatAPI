using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas.Classes
{
    public class Moneta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public float Value { get; set; }

        public int? WalletId { get; set; }
        public virtual Portfel Wallet { get; set; }

        public int VendingMachineId { get; set; }
        public virtual Automat VendingMachine { get; set; }
    }
}
