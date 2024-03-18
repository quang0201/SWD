
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelViews.Models;
using ModelViews.ModelView;
using Services.Interface;
using Services.Service;

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
                var user = User.FindFirst("id")?.Value;
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
                var user = User.FindFirst("id")?.Value;
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
                var user = User.FindFirst("id")?.Value;
                var items = await _RoomService.Delete(id, user);
                return Ok(new { status = 200, tilte = "Success", mess = "Delete success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Delete fail" });
            }
        }
        [AllowAnonymous]
        [HttpGet("pagging-room")]
        public async Task<IActionResult> GetOrdersPaging(int index, int pageSize, string? search, bool? sortDateAsc, bool? sortPriceAsc, bool? sortNameAsc)
        {
            try
            {
                var items = await _RoomService.PaggingRoom(index, pageSize, search, sortDateAsc, sortPriceAsc, sortNameAsc);

                return Ok(new { status = 200, tilte = "Success", data = items, mess = "Get items success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Get items fail" });
            }
        }
        [Authorize]
        [HttpPut("room-approve")]
        public async Task<ActionResult> ApproveFood(int id)
        {
            try
            {
                var user = User.FindFirst("id")?.Value;
                var items = await _RoomService.Approve(id, user);
                return Ok(new { status = 200, data = items, tilte = "Success", mess = "Active success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Active fail" });
            }
        }
    }
}
