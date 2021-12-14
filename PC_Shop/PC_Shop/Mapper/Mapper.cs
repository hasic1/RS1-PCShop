using AutoMapper;

namespace PC_Shop.Dal.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<PC_Shop_classLibrary.Database.Banka, PC_Shop_classLibrary.Models.BankaVM>();
            CreateMap<PC_Shop_classLibrary.Database.Proizvod, PC_Shop_classLibrary.Models.ProizvodVM>();
            CreateMap<PC_Shop_classLibrary.Database.Narudzba, PC_Shop_classLibrary.Models.NarudzbaVM>();





            CreateMap<PC_Shop_classLibrary.Models.Request.BankaModelRequest, PC_Shop_classLibrary.Database.Banka>().ReverseMap();
            CreateMap<PC_Shop_classLibrary.Models.Request.ProizvodModelRequest, PC_Shop_classLibrary.Database.Proizvod>().ReverseMap();
            CreateMap<PC_Shop_classLibrary.Models.Request.NarudzbaModelRequest, PC_Shop_classLibrary.Database.Narudzba>().ReverseMap();

        }
    }
}
