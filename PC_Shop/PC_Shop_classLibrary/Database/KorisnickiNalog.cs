using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace PC_Shop_classLibrary.Database
{
    //Table("KorisnickiNalog")]
    public abstract class KorisnickiNalog
    {
        public int ID { get; set; }
        public string korisnickoIme { get; set; }
        public string Lozinka { get; set; }

        [JsonIgnore] 
        public Korisnik korisnik => this as Korisnik;

        [JsonIgnore]
        public Administrator administrator => this as Administrator;

        public bool isKorisnik => korisnik != null;
        public bool isAdministrator => administrator  != null;
    }
}
