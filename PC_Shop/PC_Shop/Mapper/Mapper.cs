using AutoMapper;

namespace PC_Shop.Dal.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Drzava, PC_Shop_classLibrary.Models.DrzavaViewModel>();
            CreateMap<Database.Proizvod, PC_Shop_classLibrary.Models.ProizvodVM>();
            CreateMap<Database.Dostavljac, PC_Shop_classLibrary.Models.DostavljacVM>();
        }
    }
}
