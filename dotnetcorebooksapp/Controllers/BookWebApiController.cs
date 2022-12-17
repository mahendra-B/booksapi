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
        public ActionResult GetBookById(long id)
      
        {
            try
            {

                return Ok(ser.GetbyId(id));
              
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("deleterecord")]
        public IActionResult Deletebook(long id)
        {
            try
            {
                ser.delete(id);
                return Ok("record deleted...");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("updarerecord")]
        public IActionResult Updatebook(Book obj)
        {
            try
            {
                ser.update(obj);
                return Ok("record updated...");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("recordinserted")]
        public IActionResult insertbook(Book obj)
        {
            try
            {
                ser.insert(obj);
                return Ok("record inserted...");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
