using Microsoft.AspNetCore.Mvc;
using ModelViews.ModelView;
using Services.Interface;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _service;
        public FeedbackController(IFeedbackService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("view-feedback/{id}")]
        public async Task<IActionResult> ViewFeedback(int id)
        {
            try
            {
                FeedbackModel? feedback = await _service.GetFeedbackById(id);

                if (feedback == null)
                {
                    return NotFound();
                }
                return Ok(feedback);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add-feedback")]
        public async Task<IActionResult> AddFeedback([FromBody] FeedbackModel feedback)
        {
            try
            {
                bool status = await _service.AddNewFeedback(feedback);

                if (status)
                {
                    return Ok("Add feedback succesful");
                }
                return BadRequest("Add feedback failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("update-feedback")]
        public async Task<IActionResult> UpdateFeedback([FromBody] FeedbackModel feedback)
        {
            try
            {
                bool status = await _service.UpdateFeedback(feedback);

                if (status)
                {
                    return Ok("Update feedback succesful");
                }
                return BadRequest("Update feedback failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-feedback/{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            try
            {
                bool status = await _service.DeleteFeedback(id);

                if (status)
                {
                    return Ok("Delete feedback succesful");
                }
                return BadRequest("Delete feedback failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
