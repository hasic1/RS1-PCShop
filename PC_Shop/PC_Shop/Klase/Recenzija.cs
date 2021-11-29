using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Klase
{
    public class Recenzija
    {

        public int RecenzijaID { get; set; }
        public int Ocjena { get; set; }
        public string Komentar { get; set; }
        public Proizvod Proizvod { get; set; }
        public int ProizvodId { get; set; }
    }
}
