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
    public class DrzavaService : IDrzavaService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public DrzavaService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DrzavaViewModel> GetDrzava()
        {
            var entity = _context.Drzava.ToList();

            return _mapper.Map<List<DrzavaViewModel>>(entity);
        }
    }
}
