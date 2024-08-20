//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using XuongMay_BE.Data;
//using XuongMay_BE.Contract.Repositories.Models;

//namespace XuongMay_BE.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly DataContext _context;
//        public UserController(DataContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<User>>> GetAllUsers()
//        {
//            var users = await _context.Users.ToListAsync();
//            return Ok(users);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<User>> GetUser(int id)
//        {
//            var user = await _context.Users.FindAsync(id);
//            if (user is null)
//                return NotFound("User not found!");
//            return Ok(user);
//        }

//        [HttpPost]
//        public async Task<ActionResult<List<User>>> AddUser(User user)
//        {
//            _context.Users.Add(user);
//            await _context.SaveChangesAsync();
//            return Ok(await _context.Users.ToListAsync());
//        }

//        [HttpPut]
//        public async Task<ActionResult<User>> UpdateUser(User user)
//        {
//            var dbUser = await _context.Users.FindAsync(user.Id);
//            if (dbUser is null)
//                return NotFound("User not found!");
//            dbUser.Name = user.Name;
//            dbUser.Email = user.Email;
//            dbUser.Password = user.Password;
//            dbUser.Image = user.Image;
//            await _context.SaveChangesAsync();
//            return Ok(await _context.Users.FindAsync(user.Id));
//        }

//        [HttpDelete]
//        public async Task<ActionResult<List<User>>> DeleteUser(int id)
//        {
//            var dbUser = await _context.Users.FindAsync(id);
//            if (dbUser is null)
//                return NotFound("User not found!");
//            _context.Users.Remove(dbUser);
//            await _context.SaveChangesAsync();
//            return Ok(await _context.Users.ToListAsync());
//        }
//    }
//}
