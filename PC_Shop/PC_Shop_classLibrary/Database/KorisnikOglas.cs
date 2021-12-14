using System;

namespace PC_Shop_classLibrary.Database
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
