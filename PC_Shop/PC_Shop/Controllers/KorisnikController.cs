using Microsoft.AspNetCore.Mvc;
using PC_Shop_classLibrary.Database;
using PC_Shop_classLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Dal.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnikController:ControllerBase
    {
        private readonly Context _context;

        public KorisnikController(Context context)
        {
            this._context = context;
        }

        [HttpGet]
        public List<Korisnik> GetAll(string ime_prezime)
        {
            var data = _context.Korisnik
                .Where(x => ime_prezime == null || (x.Ime + " " + x.Prezime).StartsWith(ime_prezime) || (x.Prezime + " " + x.Ime)
                .StartsWith(ime_prezime)).OrderByDescending(k => k.Prezime).ThenByDescending(k => k.Ime)
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_context.Korisnik.FirstOrDefault(k => k.ID == id)); ;
        }

        [HttpPost]
        public ActionResult Add([FromBody] KorisnikAddVM k) {
            var newKorisnik = new Korisnik
            {
                Ime = k.Ime,
                Prezime = k.Prezime,
                korisnickoIme = k.korisnickoIme,
                DatumRodjenja = k.DatumRodjenja,
                Spol = k.Spol,
                DrzavaID = k.DrzavaID
            };
            _context.Add(newKorisnik);
            _context.SaveChanges();
            return Get(newKorisnik.ID);
            
        }
    }
}
