using Microsoft.AspNetCore.Mvc;

namespace WebAPI_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JWT_Generate_token _jwtGenerateToken;

        // Constructor to inject JWT_Generate_token
        public AuthController(JWT_Generate_token jwtGenerateToken)
        {
            _jwtGenerateToken = jwtGenerateToken;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            if (userLogin.Username != "testuser" || userLogin.Password != "password")
                return Unauthorized();

            var token = _jwtGenerateToken.GenerateJwtToken(userLogin.Username);

            return Ok(new { Token = token });
        }
    }

    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
