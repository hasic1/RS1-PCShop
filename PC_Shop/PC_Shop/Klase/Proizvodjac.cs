using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Klase
{
    public class Proizvodjac
    {       
      
        public int ID { get; set; }
        public string NazivProizvodjaca { get; set; }
        public Drzava Sjediste { get; set; }
        public int SjedisteID { get; set; }

    }
}
