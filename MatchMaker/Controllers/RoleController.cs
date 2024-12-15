using Microsoft.AspNetCore.Mvc;
using MatchMaker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatchMaker.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IApplicationDbContext dbContext;
        public RoleController(IApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await dbContext.Roles.ToListAsync();
            if (roles == null || roles.Count == 0)
            {
                return NotFound("No roles found in the database");
            }
            return Ok(roles);
        }
    }
}
