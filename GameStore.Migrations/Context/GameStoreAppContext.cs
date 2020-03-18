using GameStore.DAL;

using Microsoft.EntityFrameworkCore;

namespace GameStore.Migrations.Context
{
    public class GameStoreAppContext : GameStoreContext
    {
        public GameStoreAppContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }
    }
}
