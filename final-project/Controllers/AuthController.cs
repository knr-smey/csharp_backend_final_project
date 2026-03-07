using final_project.Data;
using final_project.DTOs.Auth;
using final_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }






        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto req)
        {
            if (string.IsNullOrWhiteSpace(req.Email) || string.IsNullOrWhiteSpace(req.Password))
                return BadRequest(new { message = "Email and password are required." });

            var user = await _db.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == req.Email);

            if (user == null || user.Password != req.Password)
                return Unauthorized(new { message = "Invalid email or password." });

            var (token, expSeconds) = CreateJwtToken(user);

            return Ok(new LoginResponseDto
            {
                AccessToken = token,
                ExpiresIn = expSeconds,
                User = new
                {
                    user.Id,
                    user.Name,
                    user.Email,
                    user.Gender,
                    user.Role
                }
            });
        }

        private (string Token, int ExpiresInSeconds) CreateJwtToken(User user)
        {
            var key = _config["Jwt:Key"];
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];

            if (string.IsNullOrWhiteSpace(key))
                throw new Exception("JWT Key missing. Add Jwt settings in appsettings.Development.json");

            int expMinutes = 60;
            int.TryParse(_config["Jwt:ExpMinutes"], out expMinutes);
            if (expMinutes <= 0) expMinutes = 60;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("name", user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(expMinutes);

            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return (token, expMinutes * 60);
        }
    }
}