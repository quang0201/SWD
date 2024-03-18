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
                    return NotFound();
                }
                return Ok(partyHost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                    return Ok("Add party host succesful");
                }
                return BadRequest("Add party host failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                    return Ok("Update party host succesful");
                }
                return BadRequest("Update party host failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-party-host/{id}")]
        public async Task<IActionResult> DeletePartyHost(int id)
        {
            try
            {
                bool status = await _service.DeletePartyHost(id);

                if (status)
                {
                    return Ok("Delete party host succesful");
                }
                return BadRequest("Delete party host failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
