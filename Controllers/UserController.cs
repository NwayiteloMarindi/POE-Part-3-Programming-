using Marathon.Api.Data;
using Marathon.Api.Models.DTO;
using Marathon.Api.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Race_Day.Models.DTO;
using Race_Day.Models.Entities;

namespace Marathon.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDatabaseContext _context;
        public UserController(AppDatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult CreateUser(UserDTO user)
        {
            var userEntity = new User
            {
                 Name = user.UserAccountName,
                 Email = user.UserAccountEmail,
                 Password = user.UserAccountPassword,
                 Role = user.UserAccountRole,
                 Phone = user.UserAccountPhone
            };
            _context.Users.Add(userEntity);
            _context.SaveChanges();
            return Ok("User created successfully");
        }

    }
}
