using MatchMaker.Data;
using MatchMaker.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using MatchMaker.Services;
using MatchMaker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatchMaker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IApplicationDbContext dbContext;
        private readonly PasswordHelper passwordHelper;

        public UserController(IApplicationDbContext dbContext, PasswordHelper passwordHelper)
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
                Rank = addUserDTO.Rank,
                SummonerName = addUserDTO.SummonerName
            };

            dbContext.Users.Add(userEntity);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = userEntity.Id }, userEntity);
        }

        [HttpPut]
        public async Task<IActionResult> CompleteUser([FromBody] UpdateUserDTO updateUserDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(new { message = "Invalid input", errors });

            }

            var user = await dbContext.Users
                .Include(u => u.UserPreferences)
                .FirstOrDefaultAsync(u => u.Id == updateUserDTO.Id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            user.Bio = updateUserDTO.Bio;
            user.SummonerName = updateUserDTO.SummonerName;

            user.UserPreferences.Clear();
            foreach (var preference in updateUserDTO.Preferences)
            {
                user.UserPreferences.Add(new UserPreferences
                {
                    UserId = user.Id,
                    RoleId = preference.RoleId,
                    ChampionId = preference.ChampionId,
                    LaneId = preference.LaneId
                });
            }

            await dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
