using Microsoft.AspNetCore.Mvc;
using PC_Shop_classLibrary.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC_Shop.Dal.Helper;
using PC_Shop.Dal.Autentifikacija.ViewModels;
using static PC_Shop.Dal.Helper.AuthTokenExtension;

namespace PC_Shop.Dal.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AutentifikacijaController:ControllerBase
    {
        private readonly Context _context;

        public AutentifikacijaController(Context context)
        {
            _context = context;
        }


        [HttpPost]
        public ActionResult<LoginInformacije> Login([FromBody] LoginVM x)
        {
            //1- provjera logina
            KorisnickiNalog logiraniKorisnik = _context.KorisnickiNalog
                .FirstOrDefault(k =>
                k.korisnickoIme != null && k.korisnickoIme == x.korisnickoIme && k.Lozinka == x.lozinka);

            if (logiraniKorisnik == null)
            {
                //pogresan username i password
                return new LoginInformacije(null);
            }

            //2- generisati random string
            string randomString = TokenGenerate.Generate(10);

            //3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
            var noviToken = new AutentifikacijaToken()
            {
                IPAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                vrijednost = randomString,
                KorisnickiNalog = logiraniKorisnik,
                VrijemeEvidentiranja = DateTime.Now
            };

            _context.Add(noviToken);
            _context.SaveChanges();

            //4- vratiti token string
            return new LoginInformacije(noviToken);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            if (autentifikacijaToken == null)
                return Ok();

            _context.Remove(autentifikacijaToken);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<AutentifikacijaToken> Get()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            return autentifikacijaToken;
        }


    }
}
