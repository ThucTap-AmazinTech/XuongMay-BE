//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using XuongMay_BE.Data;
//using XuongMay_BE.Contract.Repositories.Models;
//namespace XuongMay_BE.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RoleController : ControllerBase
//    {
//        private readonly DataContext _context;
//        public RoleController(DataContext context)
//        {
//            _context = context;
//        }
//        [HttpGet]
//        public async Task<ActionResult<List<Role>>> GetAllRole()
//        {
//            var Roles = await _context.Roles.ToListAsync();
//            return Ok(Roles);
//        }
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Role>> GetRole(int id)
//        {
//            var Role = await _context.Roles.FindAsync(id);
//            if (Role is null)

//                return NotFound("Role not found!");


//            return Ok(Role);
//        }

//        [HttpPost]
//        public async Task<ActionResult<Role>> AddRole(Role role)
//        {
//            _context.Roles.Add(role);
//            await _context.SaveChangesAsync();
//            return Ok(await _context.Roles.ToArrayAsync());
//        }

//        [HttpPut]
//        public async Task<ActionResult<Role>> UpdateRole(Role role)
//        {
//            var dbRole = await _context.Roles.FindAsync(role.Id);
//            if (dbRole is null)
//                return NotFound("Role not found!");
//            dbRole.Name = dbRole.Name;
//            dbRole.Note = dbRole.Note;
//            await _context.SaveChangesAsync();
//            return Ok(await _context.Roles.FindAsync(dbRole.Id));
//        }


//        [HttpDelete("{id}")]
//        public async Task<ActionResult<List<Role>>> DeleteRole(int id)
//        {
//            var role = await _context.Roles.FindAsync(id);
//            if (role is null)
//                return NotFound("Role not found!");
//            _context.Roles.Remove(role);
//            await _context.SaveChangesAsync();
//            return Ok(await _context.Roles.ToListAsync());
//        }
//    }
//}
