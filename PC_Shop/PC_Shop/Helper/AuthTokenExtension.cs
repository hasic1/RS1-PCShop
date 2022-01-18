using Microsoft.AspNetCore.Http;
using PC_Shop_classLibrary.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace PC_Shop.Dal.Helper
{
    public static class AuthTokenExtension
    {
        public static KorisnickiNalog GetKorisnikOfAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            Context _context = httpContext.RequestServices.GetService<Context>();

            KorisnickiNalog korisnickiNalog = _context.AutentifikacijaToken.Where(x => token != null && x.vrijednost == token).Select(s => s.KorisnickiNalog).SingleOrDefault();
            return korisnickiNalog;
        }
        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["autentifikacija-token"];
            return token;
        }
    
    }
   
}
