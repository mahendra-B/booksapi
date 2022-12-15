using DALayer.genericrepo;
using DALayer.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcorebooksapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookWebApiController : ControllerBase
    {
        private IGenericrepo<Book> ser;

        public BookWebApiController(IGenericrepo<Book> serr)
        {
            ser = serr;
        }
        [HttpGet("showallbooks")]
        public IActionResult GetBooks()
        {
            try
            {
                return Ok(ser.GetAll());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            

        }
        [HttpGet("GetBookByid")]
        public ActionResult GetBookById(int id)
        
        {
            try
            {
                return Ok( ser.GetById(id));
               

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
