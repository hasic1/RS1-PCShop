using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PCWebShop.ViewModels
{
    public class KorisnikAddVM
    {
        [Required(ErrorMessage = "Obavezno polje")]
        public string korisnickoIme { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string Spol { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public DateTime DatumRodjenja { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string Lozinka { get; set; }

    }
}
