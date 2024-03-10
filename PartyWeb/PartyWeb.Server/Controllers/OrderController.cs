using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelViews;
using ModelViews.Models;
using Services.Interface;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService = default!;
        public OrderController(IOrderService orderService) { 
            _orderService = orderService;
        }

        [HttpPost("add-order")]
        public async Task<IActionResult> AddOrder(OrderModel orderModel)
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                var result = _orderService.Add(orderModel,user);
                return Ok(new { status = 200, tilte = "Success", data = orderModel, mess = "Add food fail" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Add food fail" });
            }
        }
    }
}
