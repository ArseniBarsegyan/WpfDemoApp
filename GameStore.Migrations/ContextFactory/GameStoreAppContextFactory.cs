using GameStore.Migrations.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GameStore.Migrations.ContextFactory
{
    public class GameStoreAppContextFactory : IDesignTimeDbContextFactory<GameStoreAppContext>
    {
        public GameStoreAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GameStoreAppContext>();
            optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=GamesDb;Trusted_Connection=True;");
            return new GameStoreAppContext(optionsBuilder.Options);
        }
    }
}
