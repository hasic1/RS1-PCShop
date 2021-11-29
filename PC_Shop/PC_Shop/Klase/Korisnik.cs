using PC_Shop.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Klase
{
    public class Korisnik
    {
        public string Ime   {get;set;}
        public string Prezime {get;set;}
        public string Spol  {get;set;}
        public DateTime DatumRodjenja {get;set;}
        public Drzava Drzava { get; set; }
        public int DrzavaID { get; set; } 
        public bool Pretplacen{ get; set; }
    }
}
