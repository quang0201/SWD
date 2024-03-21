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
        [HttpPost("check-room")]
        public async Task<IActionResult> CheckRoomBooking(int id,string startDate,string endDate)
        {
            try
            {
                var user = User.FindFirst("id")?.Value;
                var result = await _orderService.CheckDateRoom(id, DateTime.Parse(startDate), DateTime.Parse(endDate));
                return Ok(new { status = 200, tilte = "Success", data = result, mess = "you can book" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "The day was book" });
            }
        }
        [Authorize]
        [HttpPost("add-order")]
        public async Task<IActionResult> AddOrder(OrderModel orderModel)
        {
            try
            {
                var user = User.FindFirst("id")?.Value;
                var result = await _orderService.Add(orderModel,user);
                return Ok(new { status = 200, tilte = "Success", data = result, mess = "Create order successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Create order fail" });
            }
        }
        [Authorize]
        [HttpGet("get-order-customer")]
        public async Task<IActionResult> GetOrderCustomer(int index, int pageSize, bool? sortDateAsc, bool? sortPriceAsc)
        {
            try
            {
                var user = User.FindFirst("id")?.Value;
                var result = await _orderService.GetPaggingOrder(user,index,pageSize,sortDateAsc,sortPriceAsc);
                return Ok(new { status = 200, tilte = "Success", data = result, mess = "Create order success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Create order fail" });
            }
        }
        [Authorize]
        [HttpGet("get-order-host-food")]
        public async Task<IActionResult> GetOrderHostFood(int index, int pageSize, bool? sortDateAsc, bool? sortPriceAsc)
        {
            try
            {
                var user = User.FindFirst("id")?.Value;
                var result = await _orderService.PaggingFoodHost(user, index, pageSize, sortDateAsc, sortPriceAsc);
                
                return Ok(new { status = 200, tilte = "Success", data = result, mess = "Create order success" });
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
                var user = User.FindFirst("id")?.Value;
                return Ok(new { status = 200, tilte = "Success", data = "fine", mess = "Create order success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", error = ex.Message, mess = "Create order fail" });
            }
        }
    }
}
