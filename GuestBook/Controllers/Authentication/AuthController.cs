using GuestBook.Models.User;
using GuestBook.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GuestBook.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        public UserService userService ;

        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration? configuration) {
            if (configuration != null) {
                userService = new UserService(configuration);
                _configuration = configuration;
            }
             
             
                
        }

    
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult register([FromBody] User user) {
            if (user != null) {
                try {
                    bool isRegistered = userService.signUp(user);

                    string token = generateJWT(user);
                    return isRegistered ? Ok(token) : BadRequest();
                }
                catch (Exception e) { 
                    return StatusCode(500, e.Message);
                }
            }
            return NotFound();
   
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult login([FromBody] LoginUser user) {
            if (user != null) { 
                return userService.login(user) ? Ok() : NotFound("User is not found");
            }
            return NotFound();
        }

        private string generateJWT(User user) {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Security").GetValue<String>("JwtToken")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Sub, user.Name),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim("id", user.Id.ToString()),
    };

            var token = new JwtSecurityToken("YousefGamal",
              "YousefGamal",
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

          
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
