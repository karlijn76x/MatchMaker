using Microsoft.EntityFrameworkCore;
using MatchMaker.Models.Entities;
using MatchMaker.Interfaces;

namespace MatchMaker.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Champion> Champions { get; set; }
        public DbSet<Lane> Lanes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserPreferences> UserPreferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserPreferences>()
                .HasKey(up => new { up.UserId, up.RoleId, up.LaneId, up.ChampionId });

            modelBuilder.Entity<UserPreferences>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserPreferences)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserPreferences>()
                .HasOne(up => up.Role)
                .WithMany(r => r.UserPreferences)
                .HasForeignKey(up => up.RoleId);

            modelBuilder.Entity<UserPreferences>()
                .HasOne(up => up.Lane)
                .WithMany(l => l.UserPreferences)
                .HasForeignKey(up => up.LaneId);

            modelBuilder.Entity<UserPreferences>()
                .HasOne(up => up.Champion)
                .WithMany(c => c.UserPreferences)
                .HasForeignKey(up => up.ChampionId);

        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
