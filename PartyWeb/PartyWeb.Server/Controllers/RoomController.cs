
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelViews.Models;
using ModelViews.ModelView;
using Services.Interface;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        IRoomService _RoomService;
        public RoomController(IRoomService RoomService)
        {
            _RoomService = RoomService;
        }

        [Authorize]
        [HttpPost("add-Room")]
        public async Task<IActionResult> AddRoom(RoomModel Room)
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                var result = await _RoomService.AddRoom(Room, user);
                return Ok(new { status = 200, tilte = "Success", data = Room, mess = "Add Room success" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Add Room fail" });
            }
        }

        [Authorize]
        [HttpPut("Room-update")]
        public async Task<IActionResult> UpdateRoom(UpdateRoomModel Room)
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                var items = await _RoomService.Update(Room, user);
                return Ok(new { status = 200, tilte = "Success", data = items, mess = "Update success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Update fail" });
            }
        }
        [Authorize]
        [HttpDelete("Room-delete/{id}")]
        public async Task<ActionResult> DeleteRoom(int id)
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                var items = await _RoomService.Delete(id, user);
                return Ok(new { status = 200, tilte = "Success", mess = "Delete success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Delete fail" });
            }
        }
    }
}
