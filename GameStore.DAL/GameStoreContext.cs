using GameStore.DAL.Models;

using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL
{
    public class GameStoreContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }

        public GameStoreContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
    }
}
