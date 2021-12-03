using Microsoft.AspNetCore.Mvc;
using PC_Shop_classLibrary.Service.Interface;
using System.Collections.Generic;

namespace PC_Shop.Dal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankaController : ControllerBase
    {
        private readonly IBankaService _service;

        public BankaController(IBankaService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<PC_Shop_classLibrary.Models.BankaVM> GetAll()
        {
            return _service.GetBanka();
        }
        [HttpPost]
        public PC_Shop_classLibrary.Models.Request.BankaModelRequest inserBanka([FromBody] PC_Shop_classLibrary.Models.Request.BankaModelRequest request)
        {
            return _service.insertBanka(request);
        }
    }
}
