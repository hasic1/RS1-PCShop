﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Database
{
    [Table("Korisnik")]
    public class Korisnik:KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Spol { get; set; }
        public DateTime DatumRodjenja { get; set; }
        [ForeignKey(nameof(DrzavaID))]
        public Drzava Drzava { get; set; }
        public int DrzavaID { get; set; }
        public bool Pretplacen { get; set; }
    }
}