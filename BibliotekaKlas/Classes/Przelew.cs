using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas.Classes
{
    public class Przelew: Dzialanie<double>
    {
        [Required]
        public int FromAccountId { get; set; }

        [Required]
        public int ToAccountId { get; set; }
    }
}
