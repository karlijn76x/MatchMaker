using Microsoft.EntityFrameworkCore;
using MatchMaker.Models.Entities;

namespace MatchMaker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Champion> Champions { get; set; }
        public DbSet<Lane> Lanes { get; set; }

    }
}
