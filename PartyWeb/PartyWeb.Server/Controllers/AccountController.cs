using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IDecorService _DecorService;
        public AccountController(IDecorService DecorService)
        {
            _DecorService = DecorService;
        }
    }
}
