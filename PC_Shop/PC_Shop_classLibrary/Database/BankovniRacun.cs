using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Database
{
    public class BankovniRacun
    {
        public int  ID { get; set; }
        public Korisnik Korisnik { get; set; }
        public int KorisnikID { get; set; }
        public Banka Banka { get; set; }
        public int BankaID { get; set; }
        public string BrojRacuna { get; set; }
        public DateTime DatumAktiviranjaRacuna{ get; set; }
        public double StanjeRacuna { get; set; }

    }
}
