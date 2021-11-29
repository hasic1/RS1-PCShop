using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Klase
{
    public class Post
    {
        public int ID { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public Korisnik AutorPosta { get; set; }
        public int KorisnikID { get; set; }
        public string LokacijaSlike { get; set; }
        public DateTime DatumObjave{ get; set; }

    }
}
