using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PC_Shop_classLibrary.Database
{
    public class AutentifikacijaToken
    {
        public int ID { get; set; }
        public string vrijednost { get; set; }
        [ForeignKey(nameof(KorisnickiNalog))]
        public int KorisnickiNalogID { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
        public string IPAdresa { get; set; }
    }
}
