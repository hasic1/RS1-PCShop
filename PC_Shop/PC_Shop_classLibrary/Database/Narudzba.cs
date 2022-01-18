using System;
using System.Collections.Generic;

namespace PC_Shop_classLibrary.Database
{
    public class Narudzba
    {
        public int ID { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public Korisnik Narucioc { get; set; }
        public int NaruciocID { get; set; }
        public Dostavljac Dostavljac { get; set; }
        public int DostavljacID { get; set; }
        public bool Aktivna { get; set; }
        public bool Potvrdjena { get; set; }
        public ICollection<NarudzbaStavka>NarudzbaStavke { get; set; } 
    }
}