using AutoMapper;
using PC_Shop.Database;
using PC_Shop_classLibrary.Models;
using PC_Shop_classLibrary.Models.Request;
using PC_Shop_classLibrary.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PC_Shop_classLibrary.Service
{
   public class NarudzbaService:INarudzbaService
    {
        private readonly IMapper _mapper;
        private readonly Context _context;

        public NarudzbaService(IMapper mapper, Context context)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<NarudzbaVM> GetNarudzba() 
        {
            var entitiy = _context.Narudzba.ToList();
            return _mapper.Map<List<NarudzbaVM>>(entitiy);
        }
        public NarudzbaModelRequest insertNarudzba(NarudzbaModelRequest request)
        {
            var narudzbaEntity = _mapper.Map<Narudzba>(request);
            _context.Narudzba.Add(narudzbaEntity);
            _context.SaveChanges();
            return _mapper.Map<NarudzbaModelRequest>(narudzbaEntity);
        }
    }
}
