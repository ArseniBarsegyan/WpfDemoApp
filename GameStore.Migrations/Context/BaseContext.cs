using Microsoft.EntityFrameworkCore;

namespace GameStore.Migrations.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }
    }
}
