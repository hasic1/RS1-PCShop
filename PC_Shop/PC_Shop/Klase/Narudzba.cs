using PC_Shop.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Klase
{
    public class Narudzba
    {
        public int ID { get; set;}
        public  DateTime DatumKreireanja  {get;set;}
        public Korisnik Narucioc {get;set;}
        public int NaruciocID {get;set;}
        public Dostavljac Dostavljac { get; set; }
        public int DostavljacID { get; set; }
        public bool Aktivna { get; set; }
        public bool Potvrdjena { get; set; }
       
    }
}
