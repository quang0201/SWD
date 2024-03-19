using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using ModelViews.ModelView;
using Services.Interface;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyHostController : ControllerBase
    {
        private readonly IPartyHostService _service;
        public PartyHostController(IPartyHostService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("view-party-host/{id}")]
        public async Task<IActionResult> ViewPartyHost(int id)
        {
            try
            {
                PartyHostModel? partyHost = await _service.GetPartyHostById(id);

                if (partyHost == null)
                {
                    throw new Exception("party host not found");
                }
                return Ok(new { status = 200, tilte = "Success", data = partyHost, message = "Get party host successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Get party host failed" });
            }
        }

        [HttpPost]
        [Route("add-party-host")]
        public async Task<IActionResult> AddPartyHost([FromBody] PartyHostModel partyHost)
        {
            try
            {
                bool status = await _service.AddNewPartyHost(partyHost);

                if (status)
                {
                    return Ok(new { status = 200, tilte = "Success", data = partyHost, message = "Add party host successful" });
                }
                throw new Exception("Add party host failed");
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Add party host failed" });
            }
        }

        [HttpPost]
        [Route("update-party-host")]
        public async Task<IActionResult> UpdatePartyHost([FromBody] PartyHostModel partyHost)
        {
            try
            {
                bool status = await _service.UpdatePartyHost(partyHost);

                if (status)
                {
                    return Ok(new { status = 200, tilte = "Success", data = partyHost, message = "Update party host successful" });
                }
                throw new Exception("Update party host failed");
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Update party host failed" });
            }
        }

        [HttpDelete]
        [Route("delete-party-host/{id}")]
        public async Task<IActionResult> DeletePartyHost(int id)
        {
            try
            {
                PartyHostModel? partyHost = await _service.GetPartyHostById(id);

                if (partyHost == null)
                {
                    throw new Exception("party host not found");
                }

                bool status = await _service.DeletePartyHost(id);

                if (status)
                {
                    return Ok(new { status = 200, tilte = "Success", data = partyHost, message = "Delete party host successful" });
                }
                throw new Exception("Delete party host failed");
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, tilte = "Error", data = ex.Message, message = "Delete party host failed" });
            }
        }
    }
}
