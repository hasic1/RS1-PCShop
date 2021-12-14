namespace PC_Shop_classLibrary.Database
{
    public class Recenzija
    {

        public int RecenzijaID { get; set; }
        public int Ocjena { get; set; }
        public string Komentar { get; set; }
        public Proizvod Proizvod { get; set; }
        public int ProizvodId { get; set; }
    }
}
