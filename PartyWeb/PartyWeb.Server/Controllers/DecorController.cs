using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelViews;
using Reponsitories.DecorRepositores;

namespace PartyWeb.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DecorController : ControllerBase
    {
        private IDecorService _decorService = new DecorService();
        public DecorController()
        {
        }

        [Authorize]
        [HttpGet("GetDecors")]
        public IActionResult GetDecors()
        {
            try
            {
                
                List<Decor> decors = _decorService.GetDecors();
                return Ok(decors);

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }

        [Authorize]
        [HttpGet("GetDecorsById/{id}")]
        public IActionResult GetDecorsById(int id)
        {
            try
            {

                Decor decors = _decorService.GetDecorsById(id);
                return Ok(decors);

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }

        [Authorize]
        [HttpPost("CreateDecors")]
        public IActionResult CreateDecors(FormTest d)
        {
            try
            {
                //_decorService.CreateDecors(d);
                return Ok("Create Sucessfull");

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }

        [Authorize]
        [HttpDelete("DeleteDecors")]
        public IActionResult DeleteDecors(int id)
        {
            try
            {

                _decorService.DeleteDecors(id);
                return Ok(new { mess = "Delete Sucessfull" });

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }

        [Authorize]
        [HttpPut("UpdateDecors")]
        public IActionResult UpdateDecors(Decor d)
        {
            try
            {

                _decorService.UpdateDecors(d);
                return Ok("Update Sucessfull");

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }


    }
}
