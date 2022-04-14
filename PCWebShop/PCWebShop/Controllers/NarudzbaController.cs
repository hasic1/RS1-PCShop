using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCWebShop.Data;
using PCWebShop.Database;
using PCWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
   
    public class NarudzbaController:ControllerBase
    {
        private readonly Context _context;

        public NarudzbaController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public List<NarudzbaVM> GetAll()
        {
           
            //KorisnickiNalog korisnik = ControllerContext.HttpContext.GetKorisnikOfAuthToken();

            //if (korisnik == null || korisnik is Korisnik)
            //    return null;

            var data = _context.Narudzba.OrderBy(s => s.ID)
                .Select(s => new NarudzbaVM()
                {
                    ID=s.ID,
                    Aktivna = s.Aktivna,
                    DatumKreiranja = s.DatumKreiranja,
                    DostavljacID = s.DostavljacID,
                    dostavljac=s.Dostavljac,
                    narucioc=s.Narucioc,
                    Potvrdjena = s.Potvrdjena
                }).AsQueryable();
               
            return data.Take(100).ToList();
        }

        [HttpPost]
        public ActionResult Add([FromBody] NarudzbaAddVM x)
        {
            //KorisnickiNalog korisnik = ControllerContext.HttpContext.GetKorisnikOfAuthToken();

            //if (korisnik == null || korisnik is Korisnik)
            //    return null;
            var newNarudzba = new Narudzba
            {
                Aktivna = x.Aktivna,
                Potvrdjena = x.Potvrdjena,
                DatumKreiranja = DateTime.Now,
                DostavljacID = x.DostavljacID,
                NaruciocID = x.NaruciocID
               
            };

            _context.Add(newNarudzba);
            _context.SaveChanges();
            return Get(newNarudzba.ID);
        }


        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            //KorisnickiNalog korisnik = ControllerContext.HttpContext.GetKorisnikOfAuthToken();

            //if (korisnik == null || korisnik is Korisnik)
            //    return null;

            return Ok(_context.Narudzba.Where(s => s.ID== id).FirstOrDefault());
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] NarudzbaUpdateVM x)
        {
            //KorisnickiNalog korisnik = ControllerContext.HttpContext.GetKorisnikOfAuthToken();

            //if (korisnik == null || korisnik is Korisnik)
            //    return null;

            Narudzba narudzba = _context.Narudzba.Where(s => s.ID== id).FirstOrDefault();

            if (narudzba == null)
                return BadRequest("pogresan ID");

            narudzba.NaruciocID = x.NaruciocID;
            narudzba.Potvrdjena = x.Potvrdjena;
            narudzba.Aktivna = x.Aktivna;
            narudzba.DatumKreiranja = x.DatumKreiranja;
            narudzba.DostavljacID = x.DostavljacID;

            _context.SaveChanges();
            return Get(id);
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            //KorisnickiNalog korisnik = ControllerContext.HttpContext.GetKorisnikOfAuthToken();

            //if (korisnik == null || korisnik is Korisnik)
            //    return null;

            Narudzba narudzba = _context.Narudzba.Find(id);

            if (narudzba == null)
                return BadRequest("pogresan ID");

            _context.Remove(narudzba);

            _context.SaveChanges();
            return Ok(narudzba);
        }
    }
}
