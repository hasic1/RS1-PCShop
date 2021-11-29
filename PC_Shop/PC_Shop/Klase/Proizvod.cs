using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Klase
{
    public class Proizvod
    {
      
        public int ProizvodID { get; set; }
        public string NazivProizvoda { get; set; }
        public double Cijena { get; set; }
        public int Kolicina { get; set; }
        public string Opis { get; set; }
        public Kategorija kategorija { get; set; }
        public int KategorijaID { get; set; }
        public string LokacijaSlike { get; set; }
        public bool Snizen { get; set; } = false;
        public Proizvodjac Proizvodjac { get; set; }
        public int ProizvodjacID { get; set; }

    }
}
