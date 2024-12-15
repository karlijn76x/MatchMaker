using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatchMaker.Interfaces;

namespace MatchMaker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaneController : Controller
    {
        private readonly IApplicationDbContext dbContext;
        public LaneController(IApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetLanes()
        {
            var lanes = await dbContext.Lanes.ToListAsync();
            if (lanes == null || lanes.Count == 0)
            {
                return NotFound("No champions found in the database");
            }
            return Ok(lanes);
        }
    }
}
