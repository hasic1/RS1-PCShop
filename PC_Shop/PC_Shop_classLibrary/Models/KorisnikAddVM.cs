﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PC_Shop_classLibrary.Models
{
    public class KorisnikAddVM
    {
        public string korisnickoIme { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Spol { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int DrzavaID { get; set; }
        public string Lozinka { get; set; }

    }
}