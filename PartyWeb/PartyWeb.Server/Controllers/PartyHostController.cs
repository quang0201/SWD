using Microsoft.AspNetCore.Mvc;
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
    }
}
