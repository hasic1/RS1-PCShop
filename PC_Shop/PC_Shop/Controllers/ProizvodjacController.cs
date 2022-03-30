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
    public class ProizvodjacController : ControllerBase
    {
        private readonly Context _context;

        public ProizvodjacController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Add([FromBody] ProizvodjacAddVM x)
        {
            var newProizvodjac = new Proizvodjac
            {
                NazivProizvodjaca=x.NazivProizvodjaca,
                SjedisteID=x.SjedisteID,
            };
            _context.Add(newProizvodjac);
            _context.SaveChanges();

            return Ok(newProizvodjac.ID);

        }
    }
}
