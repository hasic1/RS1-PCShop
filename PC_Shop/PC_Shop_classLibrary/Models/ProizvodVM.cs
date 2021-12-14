using PC_Shop_classLibrary.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC_Shop_classLibrary.Models
{
    public class ProizvodVM
    {
        public string NazivProizvoda { get; set; }
        public double Cijena { get; set; }
        public int Kolicina { get; set; }
        public string Opis { get; set; }
        public Kategorija kategorija { get; set; }
        public string LokacijaSlike { get; set; }
        public bool Snizen { get; set; } = false;
        public Proizvodjac Proizvodjac { get; set; }
    }
}
