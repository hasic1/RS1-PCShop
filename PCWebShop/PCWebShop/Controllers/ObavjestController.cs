using Microsoft.AspNetCore.Mvc;
using PCWebShop.Core.Interfaces;
using PCWebShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ObavjestController : ControllerBase
    {
        private readonly IObavjestService _oglasService;

        public readonly Context _context;

        public ObavjestController(IObavjestService oglasService, Context context)
        {
            _oglasService = oglasService;
            _context = context;
        }

    }
}
