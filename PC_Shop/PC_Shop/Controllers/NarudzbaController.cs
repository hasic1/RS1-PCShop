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
    public class NarudzbaController:ControllerBase
    {
        private readonly INarudzbaService _service;

        public NarudzbaController(INarudzbaService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<PC_Shop_classLibrary.Models.NarudzbaVM> GetAll() 
        {
            return _service.GetNarudzba();
        }
        [HttpPost]
        public PC_Shop_classLibrary.Models.Request.NarudzbaModelRequest insertNarudzba([FromBody] PC_Shop_classLibrary.Models.Request.NarudzbaModelRequest request) 
        {
            return _service.insertNarudzba(request);
        }
    }
}
