using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reponsitories.RoomRepositores;

namespace PartyWeb.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private IRoomService _RoomService = new RoomService();
        public RoomController()
        {
        }

        [Authorize]
        [HttpGet("GetRooms")]
        public IActionResult GetRooms()
        {
            try
            {
                
                List<Room> Rooms = _RoomService.GetRooms();
                return Ok(Rooms);

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }

        [Authorize]
        [HttpGet("GetRoomsById/{id}")]
        public IActionResult GetRoomsById(int id)
        {
            try
            {

                Room Rooms = _RoomService.GetRoomsById(id);
                return Ok(Rooms);

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }

        [Authorize]
        [HttpPost("CreateRooms")]
        public IActionResult CreateRooms(Room d)
        {
            try
            {
                _RoomService.CreateRooms(d);
                return Ok("Create Sucessfull");

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }

        [Authorize]
        [HttpDelete("DeleteRooms")]
        public IActionResult DeleteRooms(int id)
        {
            try
            {

                _RoomService.DeleteRooms(id);
                return Ok("Delete Sucessfull");

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }

        [Authorize]
        [HttpPut("UpdateRooms")]
        public IActionResult UpdateRooms(Room d)
        {
            try
            {

                _RoomService.UpdateRooms(d);
                return Ok("Update Sucessfull");

            }
            catch (Exception)
            {
                return BadRequest(new { error = "error" });
            }
        }


    }
}
