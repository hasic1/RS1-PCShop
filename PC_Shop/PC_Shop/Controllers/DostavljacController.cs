using Microsoft.AspNetCore.Mvc;
using PC_Shop_classLibrary.Service.Interface;
using System.Collections.Generic;

namespace PC_Shop.Dal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DostavljacController : ControllerBase
    {
        private readonly IDostavljacService _service;

        public DostavljacController(IDostavljacService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<PC_Shop_classLibrary.Models.DostavljacVM> GetAll()
        {
            return _service.GetDostavljac();
        }
    }
}
