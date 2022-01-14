using Microsoft.AspNetCore.Mvc;
using PC_Shop_classLibrary.Database;
using System;
using PC_Shop_classLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Dal.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
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
        [HttpPost("{id}")]
       public ActionResult Update(int id ,[FromBody] DrzavaUpdateVM x) 
        {
            Drzava drzava = _context.Drzava.Where(d => d.ID == id).FirstOrDefault();

            if (drzava == null)
                return BadRequest("pogresan ID");

            drzava.Naziv = x.Naziv;

            _context.SaveChanges();
            return Ok(drzava);
        
        }
        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Drzava drzava = _context.Drzava.Find(id);

            if (drzava == null )
                return BadRequest("pogresan ID");

            _context.Remove(drzava);

            _context.SaveChanges();
            return Ok(drzava);
        }
    }
}
