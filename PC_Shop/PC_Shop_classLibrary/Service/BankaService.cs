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
    public class BankaService : IBankaService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public BankaService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<BankaVM> GetBanka()
        {
            var entity = _context.Banka.ToList();

            return _mapper.Map<List<BankaVM>>(entity);
        }

        public BankaModelRequest insertBanka(BankaModelRequest request)
        {
            var bankaEntity = _mapper.Map<Banka>(request);

            _context.Banka.Add(bankaEntity);
            _context.SaveChanges();
            return _mapper.Map<BankaModelRequest>(bankaEntity);
        }
    }
}
