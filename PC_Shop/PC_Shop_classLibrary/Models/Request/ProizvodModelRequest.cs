using PC_Shop.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC_Shop_classLibrary.Models.Request
{
    public class ProizvodModelRequest
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
