using System;
using System.Collections.Generic;
using System.Text;

namespace PC_Shop_classLibrary.Database
{
    public abstract class KorisnickiNalog
    {
        public int ID { get; set; }
        public string korisnickoIme { get; set; }
        public string Lozinka { get; set; }
       
    }
}
