using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas.Classes
{
    public abstract class Dzialanie<T>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public T Value { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
