using AutoMapper;

namespace PC_Shop.Dal.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Banka, PC_Shop_classLibrary.Models.BankaVM>();
            CreateMap<Database.Proizvod, PC_Shop_classLibrary.Models.ProizvodVM>();
            CreateMap<Database.Narudzba, PC_Shop_classLibrary.Models.NarudzbaVM>();





            CreateMap<PC_Shop_classLibrary.Models.Request.BankaModelRequest, Database.Banka>().ReverseMap();
            CreateMap<PC_Shop_classLibrary.Models.Request.ProizvodModelRequest, Database.Proizvod>().ReverseMap();
            CreateMap<PC_Shop_classLibrary.Models.Request.NarudzbaModelRequest, Database.Narudzba>().ReverseMap();

        }
    }
}
