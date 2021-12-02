using AutoMapper;
using PC_Shop.Database;
using PC_Shop_classLibrary.Models;
using PC_Shop_classLibrary.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace PC_Shop_classLibrary.Service
{
    public class ProizvodService : IProizvodService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ProizvodService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ProizvodVM> GetProizvod()
        {
            var entity = _context.Proizvod.ToList();
            return _mapper.Map<List<ProizvodVM>>(entity);
        }
    }
}
