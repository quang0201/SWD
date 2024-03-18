using BusinessObjects.Models;
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
                    throw new Exception("Feedback not found");
                }
                return Ok(new { status = 200, tilte = "Success", data = feedback, message = "Get feedback successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Get feedback failed" });
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
                    return Ok(new { status = 200, tilte = "Success", data = feedback, message = "Add feedback successful" });
                }
                throw new Exception("Add feedback failed");
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Add feedback failed" });
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
                    return Ok(new { status = 200, tilte = "Success", data = feedback, message = "Update feedback successful" });
                }
                throw new Exception("Update feedback failed");
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Update feedback failed" });
            }
        }

        [HttpDelete]
        [Route("delete-feedback/{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            try
            {
                FeedbackModel? feedback = await _service.GetFeedbackById(id);

                if (feedback == null)
                {
                    throw new Exception("Feedback not found");
                }

                bool status = await _service.DeleteFeedback(id);

                if (status)
                {
                    return Ok(new { status = 200, tilte = "Success", data = feedback, message = "Delete feedback successful" });
                }
                throw new Exception("Delete feedback failed");
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Delete feedback failed" });
            }
        }
    }
}
