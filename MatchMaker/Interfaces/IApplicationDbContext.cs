using Microsoft.EntityFrameworkCore;
using MatchMaker.Models.Entities;

namespace MatchMaker.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Champion> Champions { get; set; }
        DbSet<Lane> Lanes { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserPreferences> UserPreferences { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
