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
        [Authorize]
        [HttpPost("add-order")]
        public async Task<IActionResult> AddOrder(OrderModel orderModel)
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                var result = await _orderService.Add(orderModel,user);
                return Ok(new { status = 200, tilte = "Success", data = orderModel, mess = "Create order successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Create order fail" });
            }
        }
        [Authorize]
        [HttpGet("get-order-customer")]
        public async Task<IActionResult> GetOrderCustomer()
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                return Ok(new { status = 200, tilte = "Success", data = "fine", mess = "Create order success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Create order fail" });
            }
        }
        [Authorize]
        [HttpGet("get-order-host")]
        public async Task<IActionResult> GetOrderHost()
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                return Ok(new { status = 200, tilte = "Success", data = "fine", mess = "Create order success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Create order fail" });
            }
        }
        [Authorize]
        [HttpPut("approve-order-host")]
        public async Task<IActionResult> ApproveOrder(int id, int status)
        {
            try
            {
                var user = User.FindFirst("user")?.Value;
                return Ok(new { status = 200, tilte = "Success", data = "fine", mess = "Create order success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Create order fail" });
            }
        }
    }
}
