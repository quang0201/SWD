using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using ModelViews.ModelView;
using Services.Interface;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyPostController : ControllerBase
    {
        private readonly IPartyPostService _service;
        public PartyPostController(IPartyPostService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("view-party-post/{id}")]
        public async Task<IActionResult> ViewPartyPost(int id)
        {
            try
            {
                PartyPostModel? partyPost = await _service.GetPartyPostById(id);

                if (partyPost == null)
                {
                    throw new Exception("party post not found");
                }
                return Ok(new { status = 200, tilte = "Success", data = partyPost, message = "Get party post successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Get party post failed" });
            }
        }

        [HttpPost]
        [Route("add-party-post")]
        public async Task<IActionResult> AddPartyPost([FromBody] PartyPostModel partyPost)
        {
            try
            {
                bool status = await _service.AddNewPartyPost(partyPost);

                if (status)
                {
                    return Ok(new { status = 200, tilte = "Success", data = partyPost, message = "Add party post successful" });
                }
                throw new Exception("Add party post failed");
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Add party post failed" });
            }
        }

        [HttpPost]
        [Route("update-party-post")]
        public async Task<IActionResult> UpdatePartyPost([FromBody] PartyPostModel partyPost)
        {
            try
            {
                bool status = await _service.UpdatePartyPost(partyPost);

                if (status)
                {
                    return Ok(new { status = 200, tilte = "Success", data = partyPost, message = "Update party post successful" });
                }
                throw new Exception("Update party post failed");
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Update party post failed" });
            }
        }

        [HttpDelete]
        [Route("delete-party-post/{id}")]
        public async Task<IActionResult> DeletePartyPost(int id)
        {
            try
            {
                PartyPostModel? partyPost = await _service.GetPartyPostById(id);

                if (partyPost == null)
                {
                    throw new Exception("party post not found");
                }

                bool status = await _service.DeletePartyPost(id);

                if (status)
                {
                    return Ok(new { status = 200, tilte = "Success", data = partyPost, message = "Delete party post successful" });
                }
                throw new Exception("Delete party post failed");
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Delete party post failed" });
            }
        }
    }
}
