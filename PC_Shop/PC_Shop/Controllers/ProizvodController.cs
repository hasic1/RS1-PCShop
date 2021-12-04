using Microsoft.AspNetCore.Mvc;
using PC_Shop_classLibrary.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Dal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodController :ControllerBase
    {
        private readonly IProizvodService _service;

        public ProizvodController(IProizvodService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<PC_Shop_classLibrary.Models.ProizvodVM> GetALl()
        {
            return _service.GetProizvod();
        }
        [HttpPost]
        public PC_Shop_classLibrary.Models.Request.ProizvodModelRequest insertProizvod([FromBody] PC_Shop_classLibrary.Models.Request.ProizvodModelRequest request)
        {
            return _service.insertProizvod(request);
        }
    }
}
