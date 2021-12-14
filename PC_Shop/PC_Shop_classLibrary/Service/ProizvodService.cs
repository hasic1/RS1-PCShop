using AutoMapper;
using PC_Shop_classLibrary.Database;
using PC_Shop_classLibrary.Models;
using PC_Shop_classLibrary.Models.Request;
using PC_Shop_classLibrary.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace PC_Shop_classLibrary.Service
{
    public class ProizvodService : IProizvodService
    {
        private readonly IMapper _mapper;
        private readonly Context _context;

        public ProizvodService(IMapper mapper, Context context)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<ProizvodVM> GetProizvod()
        {
            var entity = _context.Proizvod.ToList();
            return _mapper.Map<List<ProizvodVM>>(entity);
        }
        public ProizvodModelRequest insertProizvod(ProizvodModelRequest request)
        {
            var proizvodEntitiy = _mapper.Map<Proizvod>(request);
            _context.Proizvod.Add(proizvodEntitiy);
            _context.SaveChanges();
            return _mapper.Map<ProizvodModelRequest>(proizvodEntitiy);
        }

        public ProizvodModelRequest Update(int id, ProizvodModelRequest ponuda)
        {
            var PonudaEntity = _context.Proizvod.Find(id);

            _context.Proizvod.Attach(PonudaEntity);
            _context.Proizvod.Update(PonudaEntity);

            _mapper.Map(ponuda, PonudaEntity);

            _context.SaveChanges();

            return _mapper.Map<ProizvodModelRequest>(PonudaEntity);
        }
        public bool Delete(int id)
        {
            var entity = _context.Proizvod.Find(id);
            if (entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}