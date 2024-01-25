using ApiManagementApp.Models.AuthAndCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoresApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpPost]
        public ActionResult Authentication(UserModel authRequest)
        {
            // Validate provider credentials
            var isAuthentication= ValidateUserCredentials(authRequest.UserName, authRequest.Password);
            // If user unauthenticated return Unauthorized(401)
            if (!isAuthentication)
                return Unauthorized();
            // Else Generate a new Token specific to the requsted user 
            var symmetric_security_key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]));
            var signing_credentials = new SigningCredentials(symmetric_security_key, SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                new List<Claim>() { },
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(1),
                signing_credentials

                );

            var Serilaized_Token = new JwtSecurityTokenHandler().WriteToken(Token);
            return Ok(Serilaized_Token);
        }

        private bool ValidateUserCredentials(string userName, string password)
        {
            return true;
        }
    }
}