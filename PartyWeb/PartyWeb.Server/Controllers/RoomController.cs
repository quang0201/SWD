using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ModelViews;
using Services.Interface;
using System.Text.Json;


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
        [HttpPost("addRoom")]
        public async Task<IActionResult> AddRoom(RoomModel Room)
        {
            var user = User.FindFirst("user")?.Value;
            if (user != null)
            {
                var acc = JsonSerializer.Deserialize<Account>(user);
                var result = await _RoomService.AddRoom(Room, acc);
                if (!result.Item2)
                {
                    return Ok(new { status = "00", data = result.Item1, mess = "thêm thất bại" });
                }
                return Ok(new { status = "00", data = result.Item1, mess = "thêm Room thành công" });
            }
            else
            {
                return Unauthorized(new { status = "01", mess = "Lỗi author" });
            }

        }
    }
}
