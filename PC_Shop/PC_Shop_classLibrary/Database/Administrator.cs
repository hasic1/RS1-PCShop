using PC_Shop_classLibrary.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC_Shop_classLibrary.Database
{
   public class Administrator:KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Spol { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Drzava Drzava { get; set; }
        public int DrzavaID { get; set; }
    }
}
