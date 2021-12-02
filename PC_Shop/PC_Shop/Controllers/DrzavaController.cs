using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PC_Shop_classLibrary.Service.Interface;

namespace PC_Shop.Dal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrzavaController : ControllerBase
    {
        private readonly IDrzavaService _service;

        public DrzavaController(IDrzavaService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<PC_Shop_classLibrary.Models.DrzavaViewModel> GetAll()
        {
            return _service.GetDrzava();
        }
    }
}
