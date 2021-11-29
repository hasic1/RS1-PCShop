using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Klase
{
    public class KorisnikOglas
    {
        public int ID { get; set; }
        public Korisnik Korisnik { get; set; }
        public int KorisnikID { get; set; }
        public Oglas Oglas { get; set; }
        public int OglasID { get; set; }
        public DateTime DatumPrijave { get; set; }

        
       

    }
}
