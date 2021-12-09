using Microsoft.AspNetCore.Mvc;
using PC_Shop.Database;
using System;
using PC_Shop_classLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Dal.Controllers
{
    public class DrzavaController:ControllerBase
    {
        private readonly Context _context;

        public DrzavaController(Context context)
        {
            this._context = context;
        }

        [HttpPost]
        public Drzava Add([FromBody] DrzavaAddVM x)
        {
            var newEmployee = new Drzava
            {
                Naziv = x.Naziv,
            };

            _context.Add(newEmployee);
            _context.SaveChanges();
            return newEmployee;
        }

        [HttpGet]
        public List<DrzavaVM> GetAll()
        {
            var data = _context.Drzava
               .OrderBy(s => s.Naziv)
               .Select(s => new DrzavaVM()
               {
                   ID = s.ID,
                   Naziv = s.Naziv,
               })
               .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
