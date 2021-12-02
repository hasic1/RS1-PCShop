namespace PC_Shop.Database
{
    public class Proizvodjac
    {       
      
        public int ID { get; set; }
        public string NazivProizvodjaca { get; set; }
        public Drzava Sjediste { get; set; }
        public int SjedisteID { get; set; }

    }
}
