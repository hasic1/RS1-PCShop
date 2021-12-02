using Microsoft.AspNetCore.Mvc;
using PC_Shop_classLibrary.Service.Interface;
using System.Collections.Generic;

namespace PC_Shop.Dal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodController :ControllerBase
    {
        private readonly IProizvodService _service;

        public ProizvodController(IProizvodService proizvod)
        {
            _service = proizvod;
        }
        [HttpGet]
        public List<PC_Shop_classLibrary.Models.ProizvodVM> GetAll()
        {
            return _service.GetProizvod();
        }
    }
}
