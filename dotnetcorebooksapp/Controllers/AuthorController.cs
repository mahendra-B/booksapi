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
    public class AuthorController : ControllerBase
    {
        private IGenericrepo<Author> ser;

        public AuthorController(IGenericrepo<Author> serr)
        {
            ser = serr;
        }
        [HttpGet("grtall")]

        public IActionResult getallauthors()
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
        [HttpGet("getbyauthorid")]
        public IActionResult getbyauthorid(int id)
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
        [HttpPost("insertauthor")]
        public IActionResult insertauthor(Author obj)
        {
            try
            {
                ser.insert(obj);
                return Ok("record inserted");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        [HttpPut("updaterecord")]
        public IActionResult updateauthor(Author id)
        {
            try
            {
                ser.update(id);
                return Ok("record updated");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("delauthor")]
        public IActionResult deleteauthor(object id)
        {
            try
            {
                ser.delete(id);
                return Ok("record deleted");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
    
}
