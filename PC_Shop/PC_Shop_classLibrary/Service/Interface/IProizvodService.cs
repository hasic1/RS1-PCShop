using System.Collections.Generic;

namespace PC_Shop_classLibrary.Service.Interface
{
    public interface IProizvodService
    {
        List<Models.ProizvodVM> GetProizvod();
        Models.Request.ProizvodModelRequest insertProizvod(Models.Request.ProizvodModelRequest request);
    }
}
