﻿using Microsoft.AspNetCore.Http;
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
    public class KategorijaController : ControllerBase
    {
        private readonly Context _context;

        public KategorijaController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Add([FromBody] KategorijaAddVM x)
        {

            var newKategorija = new Kategorija
            {

               NazivKategorije=x.NazivKategorije
            };
            _context.Add(newKategorija);
            _context.SaveChanges();

            return Ok(newKategorija.KategorijaID);

        }
    }
}
