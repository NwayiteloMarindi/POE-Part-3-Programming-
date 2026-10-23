using Marathon.Api.Data;
using Marathon.Api.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Race_Day.Data.DTO;
using Race_Day.Models.DTO;
using Race_Day.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Marathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private     readonly AppDatabaseContext _context;
        [HttpPost("register")]
        [Authorize]
        public IActionResult Register(UserDTO createUser)
            {
                var user = new User
                {
                    Id = createUser.Id,
                    Name = createUser.Name,
                    Email = createUser.Email,
                    Password = createUser.Password,
                    Role = createUser.Role,
                    Phone= createUser.Phone,
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok("User registered successfully");
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == loginDTO.Email && u.Password == loginDTO.Password);
            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }
            return Ok("Login successful");
        }
    }
}
