using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PC_Shop_classLibrary.Database;
using PC_Shop_classLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Shop.Dal.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PostController : ControllerBase
    {
        private readonly Context _context;

        public PostController(Context context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_context.Post.FirstOrDefault(p => p.ID == id));
        }
        [HttpPost]
        public ActionResult Add([FromBody] PostAddVM x)
        {

            var newPost= new Post
            {
                DatumObjave = x.DatumObjave,
                KorisnikID=x.KorisnikID,
                LokacijaSlike=x.LokacijaSlike,
                Naslov=x.Naslov,
                Sadrzaj=x.Sadrzaj                
            };
            _context.Add(newPost);
            _context.SaveChanges();

            return Ok(newPost.ID);
        }
        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] PostUpdateVM x)
        {
            Post post = _context.Post.Where(p => p.ID == id).FirstOrDefault(p => p.ID == id);

            if (post == null)
                return BadRequest("pogresan ID");

            post.KorisnikID = post.KorisnikID;
            post.LokacijaSlike = post.LokacijaSlike;
            post.Sadrzaj = post.Sadrzaj;
            post.Naslov = post.Naslov;
            post.DatumObjave = post.DatumObjave;

            _context.SaveChanges();
            return Get(id);
        }
    }
}
