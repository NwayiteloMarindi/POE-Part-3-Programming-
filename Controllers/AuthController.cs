using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private     readonly App
        [HttpPost("register")]
        [Authorize]
        public IActionResult Register()
            {
                return Ok("AuthController is working!");
        }
    }
}
