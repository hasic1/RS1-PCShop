using AutoMapper;

namespace PC_Shop.Dal.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Drzava, PC_Shop_classLibrary.Models.DrzavaViewModel>();
            CreateMap<Database.Banka, PC_Shop_classLibrary.Models.BankaVM>();


            CreateMap<PC_Shop_classLibrary.Models.Request.BankaModelRequest, Database.Banka>().ReverseMap();
        }
    }
}
