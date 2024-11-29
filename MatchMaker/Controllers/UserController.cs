using MatchMaker.Data;
using MatchMaker.Models.Entities;
using MatchMaker.Models;
using Microsoft.AspNetCore.Mvc;
using MatchMaker.Services;

namespace MatchMaker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly PasswordHelper passwordHelper;

        public UserController(ApplicationDbContext dbContext, PasswordHelper passwordHelper)
        {
            this.dbContext = dbContext;
            this.passwordHelper = passwordHelper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            dbContext.Users.ToList();
            return Ok(dbContext.Users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AddUserDTO addUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (dbContext.Users.Any(u => u.Username == addUserDTO.Username || u.Email == addUserDTO.Email))
            {
                return Conflict("Username or Email already exists.");
            }

            var hashedPassword = passwordHelper.HashPassword(addUserDTO.PasswordHash);

            var userEntity = new User
            {
                Id = Guid.NewGuid(),
                Username = addUserDTO.Username,
                PasswordHash = hashedPassword,
                Email = addUserDTO.Email,
                Region = addUserDTO.Region,
                SummonerName = addUserDTO.SummonerName
            };

            dbContext.Users.Add(userEntity);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = userEntity.Id }, userEntity);
        }

    }
}
