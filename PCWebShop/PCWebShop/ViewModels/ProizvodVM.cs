using PCWebShop.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCWebShop.ViewModels
{
    public class ProizvodVM
    {
        public int ProizvodID { get; set; }
        public string NazivProizvoda { get; set; }
        public double Cijena { get; set; }
        public int Kolicina { get; set; }
        public string Opis { get; set; }
        public int KategorijaID { get; set; }
        public string LokacijaSlike { get; set; }
        public bool Snizen { get; set; } = false;
        public int ProizvodjacID { get; set; }
    }
}
