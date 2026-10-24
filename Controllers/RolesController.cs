using Marathon.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Marathon.Api.Models.DTO;
using Race_Day.Models.Entities;

namespace Marathon.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AppDatabaseContext _context;
        public RolesController(AppDatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _context.Roles.ToList();
            return Ok(roles);
        }
        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            var role = _context.Roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
        [HttpPost]
        public IActionResult CreateRole(AddRoles role)
        {
            var roleEntity = new Roles
            {
                RoleName = role.RoleName,
                RoleDescription = role.RoleDescription
            };
            _context.Roles.Add(roleEntity);
            _context.SaveChanges();
            return Ok("Role created successfully");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id, AddRoles role)
        {
            var roleEntity = _context.Roles.Find(id);
            if (roleEntity == null)
            {
                return NotFound();
            }
            roleEntity.RoleName = role.RoleName;
            roleEntity.RoleDescription = role.RoleDescription;
            _context.SaveChanges();
            return Ok("Role updated successfully");
        }

        
    }
}
