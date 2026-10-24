using Marathon.Api.Data;
using Marathon.Api.Models.DTO;
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
        private readonly IPasswordHasher<UserAccount> _hasher;

       
        public AuthController(AppDatabaseContext context, IConfiguration config, IPasswordHasher<UserAccount> hasher)
        {
            _context= context;
            _config = config;
            _hasher = hasher;
        }
        [HttpPost("register")]
        
        public IActionResult Register(UserDTO createUser)
            {
                var user = new UserAccount
                {
                   
                    UserAccountName = createUser.UserAccountName,
                    UserAccountEmail = createUser.UserAccountEmail,
                    UserAccountPassword = null, // Password should be hashed and stored securely
                    UserAccountRole = "User",
                    UserAccountPhone = createUser.UserAccountPhone,

                    

                };
               user.UserAccountPassword = _hasher.HashPassword(user, createUser.UserAccountPassword);
            _context.Profiles.Add(user);
                _context.SaveChanges();
                return Ok("User registered successfully");
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var user = _context.Profiles.FirstOrDefault(u => u.UserAccountEmail == loginDTO.Email && u.UserAccountPassword == loginDTO.Password);
            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }
            return Ok("Login successful");
        }
        [HttpGet]
        public IActionResult GetAccount()
        {
            var accouEntity = _context.Profiles.ToList();
            return Ok(accouEntity);
        }
        [HttpGet("profiles")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetProfileAsync()
        {
            var userId = _context.Profiles.Find(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();
           
            var profile = await _context.Profiles
            .Where(u => u.UserAccountId.Equals(userId))        
            .Select(u => new                     
            {
                u.UserAccountId,
                u.UserAccountEmail,
                u.UserAccountName,
                u.UserAccountPhone,
               
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
            var profiles = await _context.Profiles
                .Select(u => new
                {
                    u.UserAccountId,
                    u.UserAccountEmail,
                    u.UserAccountName,
                    u.UserAccountPhone,
                })
                .ToListAsync();
            return Ok(profiles);
        }


    }
}
