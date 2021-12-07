using System;
using System.Collections.Generic;
using System.Text;

namespace PC_Shop_classLibrary.Service.Interface
{
   public interface INarudzbaService
    {
        List<Models.NarudzbaVM> GetNarudzba();
        Models.Request.NarudzbaModelRequest insertNarudzba(Models.Request.NarudzbaModelRequest request);
        //Models.Request.NarudzbaModelRequest Update(int id, Models.Request.NarudzbaModelRequest ponuda);
        //bool Delete(int id);
    }
}
