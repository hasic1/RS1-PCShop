using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PC_Shop_classLibrary.Database
{  
   // [Table("Korisnik")]
    public class Korisnik:KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Spol { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Drzava Drzava { get; set; }
        public int DrzavaID { get; set; }
        public bool Pretplacen { get; set; }
    }
}
