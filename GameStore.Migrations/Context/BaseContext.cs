using GameStore.DAL;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Migrations.Context
{
    public class BaseContext : GameStoreContext
    {
        public BaseContext(DbContextOptions<BaseContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }
    }
}
