using Lucas.CacauShow.UsersManagement.Contracts.Services;
using Lucas.CacauShow.UsersManagement.Models.Requests;
using Lucas.CacauShow.UsersManagement.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lucas.CacauShow.UsersManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IConfiguration _configuration;
        IUserService _userService;
        public LoginController(IConfiguration configuration, IUserService userService) {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest user)
        {
            if (user is null)
            {
                return BadRequest("login não informado!");
            }

            if (await _userService.DoLogon(user.UserName, user.Password))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Secret")));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: _configuration.GetValue<string>("JWT:ValidIssuer"),
                    audience: _configuration.GetValue<string>("JWT:ValidAudience"),
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(6),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new TokenResponse { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}