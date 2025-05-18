using Microsoft.AspNetCore.Mvc;
using RepositoryPatternDemo.Models;
using RepositoryPatternDemo.Utility.Auth;

namespace RepositoryPatternDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtToken _jwtToken;
        public LoginController(JwtToken jwtToken)
        {
                _jwtToken = jwtToken;
        }
        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest();
            }

            if (loginDto.UserName == "admin" && loginDto.Password == "password")
            {
                var token = _jwtToken.GenerateJwtToken(loginDto.UserName);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

    }
}
