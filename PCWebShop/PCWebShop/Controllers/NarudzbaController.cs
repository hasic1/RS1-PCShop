using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PCWebShop.Core.Interfaces;
using PCWebShop.Data;
using PCWebShop.Database;
using PCWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
   
    public class NarudzbaController:ControllerBase
    {
        private readonly Context _context;
        private readonly INarudzbaService _narudzbaService;

        public NarudzbaController(Context context, INarudzbaService narudzbaService)
        {
            _context = context;
            _narudzbaService = narudzbaService;
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
                    NaruciocID=s.NaruciocID,
                    Potvrdjena = s.Potvrdjena
                }).AsQueryable();
               
            return data.Take(100).ToList();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] KorpaVM request , CancellationToken cancellationToken)
        {
            var result = await _narudzbaService.AddNarudzba(request, cancellationToken);

            if (!result.IsValid)
                return BadRequest(result);

            return Ok(result);

        }


        [HttpPost]
        public ActionResult Add(int  nesto)
        {

            //KorisnickiNalog korisnik = ControllerContext.HttpContext.GetKorisnikOfAuthToken();

            //if (korisnik == null || korisnik is Korisnik)
            //    return null;
            var items = nesto;

            //var newNarudzba = new Narudzba
            //{
            //    Aktivna = x.Aktivna,
            //    Potvrdjena = x.Potvrdjena,
            //    DatumKreiranja = DateTime.Now,
            //    NaruciocID = x.NaruciocID,
            //    Dostavljac=x.dostavljac,
            //    Narucioc=x.narucioc                
            //};

            //_context.Add(newNarudzba);
            //_context.SaveChanges();
            //return Get(newNarudzba.ID);
            return Ok();
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
