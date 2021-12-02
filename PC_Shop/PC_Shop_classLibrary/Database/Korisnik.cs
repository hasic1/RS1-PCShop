using System;

namespace PC_Shop.Database
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Spol { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Drzava Drzava { get; set; }
        public int DrzavaID { get; set; }
        public bool Pretplacen { get; set; }
    }
}
