using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas.Classes
{
    public abstract class Pieniadz<T>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public T Value { get; set; }

        public int? WalletId { get; set; }
        public virtual Portfel Wallet { get; set; }

        public abstract bool isValue(T value);
    }
}
