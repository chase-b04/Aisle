using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using PostgresAPI.Models;

namespace PostgresAPI.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUser()
        {
            var result = await _context.Users.Select(x => new Users
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                CreatedAt = x.CreatedAt,
            }).ToListAsync();

            return Ok(result);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser([FromBody] Users user)
        {
            var rows = await _context.Users.Where(x => x.Id == user.Id)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.Name, user.Name));

            return Ok(user);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] Users userId)
        {
            var rows = await _context.Users.Where(x => x.Id == userId).ExecuteDeleteAsync();

            return Ok(true);
        }
    }
}