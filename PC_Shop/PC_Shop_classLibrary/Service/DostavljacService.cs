using AutoMapper;
using PC_Shop.Database;
using PC_Shop_classLibrary.Models;
using PC_Shop_classLibrary.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PC_Shop_classLibrary.Service
{
    public class DostavljacService : IDostavljacService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public DostavljacService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DostavljacVM> GetDostavljac()
        {
            throw new NotImplementedException();
        }

        public List<DostavljacVM> GetDrzava()
        {
            var entity = _context.Dostavljac.ToList();

            return _mapper.Map<List<DostavljacVM>>(entity);
        }
    }
}
