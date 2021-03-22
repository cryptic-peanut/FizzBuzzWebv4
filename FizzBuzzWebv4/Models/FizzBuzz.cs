using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzWebv4.Models
{
    public class FizzBuzz
    {
        [Required(ErrorMessage = "Błąd. Nie podano liczby.")]
        [Range(0, 1000, ErrorMessage = "Podana liczba musi zawierać się w przedziale od 0 do 1000.")]
        public int? Number { get; set; }
        public DateTime Date = DateTime.Now;
        public string Result { get; set; }
    }
}