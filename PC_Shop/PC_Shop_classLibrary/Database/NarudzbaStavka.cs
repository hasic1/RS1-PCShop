﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop_classLibrary.Database
{
    public class NarudzbaStavka
    {
        public int ID { get; set; }
        public Proizvod Proizvod { get; set; }
        public int PropizvodID { get; set; }
        public Narudzba Narudzba { get; set; }
        public int NarudzbaID { get; set; }
        public int Kolicina { get; set; }
        public double Cijena { get; set; }
    }
}
