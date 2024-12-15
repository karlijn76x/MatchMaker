using MatchMaker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatchMaker.Interfaces;

namespace MatchMaker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChampionController : ControllerBase
    {
        private readonly IApplicationDbContext dbContext;

        public ChampionController(IApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetChampions()
        {
            var champions = await dbContext.Champions.ToListAsync();
            if (champions == null || champions.Count == 0)
            {
                return NotFound("No champions found in the database");
            }
            return Ok(champions);
        }

    }
}
    

