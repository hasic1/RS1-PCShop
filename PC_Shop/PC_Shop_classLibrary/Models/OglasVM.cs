using System;
using System.Collections.Generic;
using System.Text;

namespace PC_Shop_classLibrary.Models
{
   public class OglasVM
    {
        public int ID { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public int BrojPozicja { get; set; }
        public string Lokacija { get; set; }
        public DateTime DatumObjave { get; set; } = DateTime.Now;
        public int TrajanjeOglasa { get; set; } = 0;
        public DateTime DatumIsteka { get; set; }
      
        public bool Aktivan { get; set; } = true;
    }
}
