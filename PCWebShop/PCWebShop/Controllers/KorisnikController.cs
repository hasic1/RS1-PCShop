using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using PCWebShop.Data;
using PCWebShop.Database;
using PCWebShop.Helper.AutentifikacijaAutorizacija;
using PCWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnikController : ControllerBase
    {
        private readonly Context _context;

        public KorisnikController(Context context)
        {
            this._context = context;
        }

        [HttpGet]
        public List<KorisnikVM> GetAll(string ime_prezime)
        {
            //if (!HttpContext.GetLoginInfo().isLogiran)
            //    return BadRequest("Nije logiran");

            var data = _context.Korisnik.OrderBy(s => s.id)
                .Where(x => ime_prezime == null || (x.Ime + " " + x.Prezime).StartsWith(ime_prezime) || (x.Ime + " " + x.Prezime).StartsWith(ime_prezime))
               .Select(s => new KorisnikVM()
               {
                   ID = s.id,
                   Ime = s.Ime,
                   DatumRodjenja = s.DatumRodjenja,
                   KorisnickoIme = s.korisnickoIme,
                   drzava = s.Drzava,
                   DrzavaID = s.DrzavaID,
                   Pretplacen = s.Pretplacen,
                   Prezime = s.Prezime,
                   Email=s.Email,
                   Spol = s.Spol
               }).AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_context.Korisnik.FirstOrDefault(k => k.id == id));
        }

        [HttpPost]
        public ActionResult Add([FromBody] KorisnikAddVM k)
        {
            if (k == null || !ModelState.IsValid)
                return BadRequest();
            try
            {
                var newKorisnik = new Korisnik
                {
                    DrzavaID = k.DrzavaID,
                    Ime = k.Ime,
                    Prezime = k.Prezime,
                    korisnickoIme = k.korisnickoIme,
                    DatumRodjenja = k.DatumRodjenja,
                    Spol = k.Spol,
                    lozinka = k.Lozinka,
                    Pretplacen = true,
                    Email=k.Email
                    
                };

                _context.Add(newKorisnik);
                _context.SaveChanges();
                return Get(newKorisnik.id);
            }
            catch (Exception)
            {

                throw;
            }
           
            
        }


        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] KorisnikUpdateVM x)
        {
            Korisnik korisnik = _context.Korisnik.Where(k =>k.id ==id ).FirstOrDefault(s => s.id == id);

            if (korisnik == null)
                return BadRequest("pogresan ID");

            korisnik.Ime = x.Ime;
            korisnik.Prezime = x.Prezime;
            korisnik.korisnickoIme = x.korisnickoIme;
            korisnik.lozinka = x.Lozinka;
            korisnik.Pretplacen = x.Pretplacen;          
            korisnik.DatumRodjenja = x.DatumRodjenja;
            korisnik.DrzavaID = x.DrzavaID;
            korisnik.Spol = x.Spol;
            korisnik.Email = x.Email;


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
