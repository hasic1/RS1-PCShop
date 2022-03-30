using Microsoft.AspNetCore.Http;
using PC_Shop_classLibrary.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace PC_Shop.Dal.Helper
{
    public static class AuthTokenExtension
    {
        public class LoginInformacije
        {
            public LoginInformacije(AutentifikacijaToken autentifikacijaToken)
            {
                this.autentifikacijaToken = autentifikacijaToken;
            }

            [JsonIgnore]
            public KorisnickiNalog korisnickiNalog => autentifikacijaToken?.KorisnickiNalog;
            public AutentifikacijaToken autentifikacijaToken { get; set; }


            public bool isLogiran => korisnickiNalog != null;

            public bool isPermisijaKorisnik => isLogiran && (korisnickiNalog.isKorisnik  || korisnickiNalog.isAdministrator);
            public bool isPermisijaAdministrator => isLogiran && (korisnickiNalog.isAdministrator);
        }

        public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
        {
            var token = httpContext.GetAuthToken();

            return new LoginInformacije(token);
        }

        public static AutentifikacijaToken GetAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            Context db = httpContext.RequestServices.GetService<Context>();

            AutentifikacijaToken korisnickiNalog = db.AutentifikacijaToken
                .Include(s=>s.KorisnickiNalog)
                .SingleOrDefault(x => token != null && x.vrijednost == token);
            
            return korisnickiNalog;
        }

       
        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["autentifikacija-token"];
            return token;
        }
    
    }
   
}
