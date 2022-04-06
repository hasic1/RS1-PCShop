﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PCWebShop.Data;
using PCWebShop.Database;
using PCWebShop.ViewModels;

namespace   PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OglasiController:ControllerBase
    {
        public readonly Context _context;

        public OglasiController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public List<OglasVM> GetAll()
        {

           

            var data = _context.Oglas.OrderBy(s => s.ID)
                .Select(s => new OglasVM()
                {
                    ID = s.ID,
                    Naslov = s.Naslov,
                    Sadrzaj = s.Sadrzaj,
                    Aktivan = s.Aktivan,
                    BrojPozicja = s.BrojPozicja,
                    DatumObjave = s.DatumObjave,
                    DatumIsteka = s.DatumIsteka,
                    Lokacija = s.Lokacija,
                    TrajanjeOglasa = s.TrajanjeOglasa,
                }).AsQueryable();

            return data.Take(100).ToList();
            

        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_context.Oglas.FirstOrDefault(k => k.ID == id)); ;
        }
        [HttpPost]
        public ActionResult Add([FromBody] OglasAddVM o)
        {
           
            var newOglas = new Oglas
            {
               
                Naslov = o.Naslov,
                Sadrzaj = o.Sadrzaj,
                Aktivan = o.Aktivan,
                BrojPozicja = o.BrojPozicja,
                DatumObjave = o.DatumObjave,
                DatumIsteka = o.DatumIsteka,
                Lokacija = o.Lokacija,
                TrajanjeOglasa = o.TrajanjeOglasa,
                AutorOglasaID=o.AutorOglasaID

            };

            _context.Add(newOglas);
            _context.SaveChanges();
            return Get(newOglas.ID);
        }
        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] OglasUpdateVM x)
        {
            Oglas oglas = _context.Oglas.Where(o => o.ID == id).FirstOrDefault(o => o.ID == id);

            if (oglas == null)
                return BadRequest("pogresan ID");

            oglas.Naslov = x.Naslov;
            oglas.Sadrzaj = x.Sadrzaj;
            oglas.Aktivan = x.Aktivan;
            oglas.BrojPozicja = x.BrojPozicja;
            oglas.DatumObjave = x.DatumObjave;
            oglas.DatumIsteka = x.DatumIsteka;
            oglas.Lokacija = x.Lokacija;
            oglas.TrajanjeOglasa = x.TrajanjeOglasa;


            _context.SaveChanges();
            return Get(id);
        }
        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Oglas oglas = _context.Oglas.Find(id);

            if (oglas == null)
                return BadRequest("pogresan ID");

            _context.Remove(oglas);

            _context.SaveChanges();
            return Ok(oglas);
        }
    }
}