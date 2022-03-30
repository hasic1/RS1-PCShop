using System;
using System.Collections.Generic;
using System.Text;

namespace PC_Shop_classLibrary.Models
{
    public class PostUpdateVM
    {
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public int KorisnikID { get; set; }
        public string LokacijaSlike { get; set; }
        public DateTime DatumObjave { get; set; }
    }
}
