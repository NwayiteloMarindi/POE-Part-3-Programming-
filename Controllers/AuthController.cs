using Marathon.Api.Data;
using Marathon.Api.Models.DTO;
using Marathon.Api.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Race_Day.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Marathon.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDatabaseContext _context;
        private readonly IConfiguration _config;
        private readonly IPasswordHasher<User> _hasher;

       
        public AuthController(AppDatabaseContext context, IConfiguration config, IPasswordHasher<User> hasher)
        {
            _context= context;
            _config = config;
            _hasher = hasher;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUser createUser)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            if (await _context.Users.AnyAsync(u => u.Email == createUser.Email))
                return Conflict("Email is already registered.");

            var user = new User
            {
                Name = createUser.Name,
                Email = createUser.Email,
                Phone = createUser.Phone,
                Role = "User",
                Password = "",                                    // placeholder (if entity requires it)
            };
            user.Password = _hasher.HashPassword(user, createUser.Password);   // ← fixed line

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

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
        [HttpGet]
        public IActionResult GetAccount()
        {
            var accouEntity = _context.Users.ToList();
            return Ok(accouEntity);
        }
        [HttpGet("profiles")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetProfileAsync()
        {
            var userId = _context.Users.Find(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();
           
            var profile = await _context.Users
            .Where(u => u.Id.Equals(userId))        
            .Select(u => new                     
            {
                u.Id,
                u.Email,
                u.Name,
                u.Phone,
               
            })
            .FirstOrDefaultAsync();

            if (profile is null)
                return NotFound();

            return Ok(profile);
        }
        [HttpGet("profile")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllProfilesAsync()
        {
            var profiles = await _context.      Users   
                .Select(u => new
                {
                    u.Id,
                    u.Email,
                    u.Name,
                    u.Phone,
                })
                .ToListAsync();
            return Ok(profiles);
        }


    }
}
