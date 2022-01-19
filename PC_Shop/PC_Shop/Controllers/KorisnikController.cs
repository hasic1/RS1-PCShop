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
        public List<KorisnikVM> GetAll(string ime_prezime)
        {
            var data = _context.Korisnik.OrderBy(s => s.ID)
               .Select(s => new KorisnikVM()
               {
                   ID = s.ID,
                   Ime = s.Ime,
                   DatumRodjenja = s.DatumRodjenja,
                   KorisnickoIme = s.korisnickoIme,
                   DrzavaID = s.DrzavaID,
                   Pretplacen = s.Pretplacen,
                   Prezime=s.Prezime,
                   Spol=s.Spol
               }).AsQueryable();

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
                DrzavaID = k.DrzavaID,
                Lozinka=k.Lozinka,
                Pretplacen=true
                
            };
            _context.Add(newKorisnik);
            _context.SaveChanges();
            return Get(newKorisnik.ID);
            
        }
        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] KorisnikUpdateVM x)
        {
            Korisnik korisnik = _context.Korisnik.Where(k =>k.ID ==id ).FirstOrDefault(s => s.ID == id);

            if (korisnik == null)
                return BadRequest("pogresan ID");

            korisnik.Ime = x.Ime;
            korisnik.Prezime = x.Prezime;
            korisnik.korisnickoIme = x.korisnickoIme;
            korisnik.Lozinka = x.Lozinka;
            korisnik.Pretplacen = x.Pretplacen;          
            korisnik.DatumRodjenja = x.DatumRodjenja;
            korisnik.DrzavaID = x.DrzavaID;
            korisnik.Spol = x.Spol;


            _context.SaveChanges();
            return Get(id);
        }
        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Korisnik korisnik = _context.Korisnik.Find(id);

            if (korisnik == null  )
                return BadRequest("pogresan ID");

            _context.Remove(korisnik);

            _context.SaveChanges();
            return Ok(korisnik);
        }
    }
}
