using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PC_Shop.Dal.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Dal.Autentifikacija
{
    public class AutorizacijaAtribute : TypeFilterAttribute
    {
        public AutorizacijaAtribute(bool studentskaSluzba, bool prodekan, bool dekan, bool admin, bool studenti, bool nastavnici)
           : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { };
        }

        public class MyAuthorizeImpl : IActionFilter
        {

            private readonly bool _korisnici;
            private readonly bool _administratori;

            public MyAuthorizeImpl(bool korisnik, bool administrator)
            {
                _korisnici = korisnik;
                _administratori = administrator;
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {


            }

            public void OnActionExecuting(ActionExecutingContext filterContext)
            {

                if (filterContext.HttpContext.GetLoginInfo().isLogiran)
                {
                    filterContext.Result = new UnauthorizedResult();
                    return;
                }

                KretanjePoSistemu.Save(filterContext.HttpContext);

                if (filterContext.HttpContext.GetLoginInfo().isPermisijaAdministrator)
                {
                    return;//ok - ima pravo pristupa
                }
                if (filterContext.HttpContext.GetLoginInfo().isPermisijaKorisnik && _korisnici)
                {
                    return;//ok - ima pravo pristupa
                }


                //else nema pravo pristupa
                filterContext.Result = new UnauthorizedResult();
            }


        }
    }
}
