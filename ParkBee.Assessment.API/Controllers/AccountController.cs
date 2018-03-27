using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ParkBee.Assessment.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("token"), AllowAnonymous]
        public IActionResult RequestToken([FromBody] TokenRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = Authenticate(request.Username, request.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = GetJwtSecurityToken(user);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        private UserModel Authenticate(string username, string password) =>
            // For simple authentication we just compare username and password
            username.Equals(password)
                ? new UserModel
                {
                    Name = "Joe Soap",
                    Email = "joe@mailinator.com",
                    GarageId = 2
                }
                : default(UserModel);

        private JwtSecurityToken GetJwtSecurityToken(UserModel user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ParkBeeClaimTypes.GarageId, user.GarageId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return token;
        }
    }

    public class TokenRequestModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class UserModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int GarageId { get; set; }
    }
}