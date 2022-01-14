using System;
using System.Collections.Generic;
using System.Text;

namespace PC_Shop_classLibrary.Models
{
  public  class NarudzbaAddVM
    {
        public DateTime DatumKreireanja { get; set; }
        public int NaruciocID { get; set; }
        public int DostavljacID { get; set; }
        public bool Aktivna { get; set; }
        public bool Potvrdjena { get; set; }
    }
}
